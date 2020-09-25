using eShopSolution.Utilities.Constants;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Service
{
    public class ProductApiClient : BaseApiClient, IProductApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> CreateProduct(ProductCreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var languageId = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();
            if (request.thumbnail_image != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.thumbnail_image.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.thumbnail_image.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "thumbnail_image", request.thumbnail_image.FileName);
            }

            requestContent.Add(new StringContent(request.price.ToString()), "price");
            requestContent.Add(new StringContent(request.original_price.ToString()), "original_price");
            requestContent.Add(new StringContent(request.stock.ToString()), "stock");
            requestContent.Add(new StringContent(request.name.ToString()), "name");
            requestContent.Add(new StringContent(request.description.ToString()), "description");

            requestContent.Add(new StringContent(request.details.ToString()), "details");
            requestContent.Add(new StringContent(request.seo_description.ToString()), "seo_description");
            requestContent.Add(new StringContent(request.seo_title.ToString()), "seo_title");
            requestContent.Add(new StringContent(request.seo_alias.ToString()), "seo_alias");
            requestContent.Add(new StringContent(languageId), "language_id");

            var response = await client.PostAsync($"/api/products/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<PagedResult<ProductViewModel>> GetProductsByPaging(GetManageProductPagingRequest request)
        {
            var data = await GetAsync<PagedResult<ProductViewModel>>(
                $"/api/products/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.Pagesize}" +
                $"&keyword={request.Keyword}&languageId={request.LanguageId}");
            return data;
        }
    }
}