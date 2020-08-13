using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<AppConfig>().HasData(
                        new AppConfig() { key = "HomeTitle", value = "This is home page of eShopSolution" },
                        new AppConfig() { key = "HomeKeywork", value = "This is key work of eShopSolution" },
                        new AppConfig() { key = "HomeDescription", value = "This is Description of eShopSolution" }
                        );
            modelBuilder.Entity<Language>().HasData(
            new Language() { id = "vi-VN", name = "Tiếng Việt", is_default = true },
            new Language() { id = "en-US", name = "English", is_default = false });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    id = 1,
                    is_show_on_home = true,
                    parent_id = null,
                    sort_order = 1,
                    status = Status.Active,
                },
                 new Category()
                 {
                     id = 2,
                     is_show_on_home = true,
                     parent_id = null,
                     sort_order = 2,
                     status = Status.Active
                 });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                  new CategoryTranslation() { id = 1, category_id = 1, name = "Áo nam", language_id = "vi-VN", seo_alias = "ao-nam", seo_description = "Sản phẩm áo thời trang nam", seo_title = "Sản phẩm áo thời trang nam" },
                  new CategoryTranslation() { id = 2, category_id = 1, name = "Men Shirt", language_id = "en-US", seo_alias = "men-shirt", seo_description = "The shirt products for men", seo_title = "The shirt products for men" },
                  new CategoryTranslation() { id = 3, category_id = 2, name = "Áo nữ", language_id = "vi-VN", seo_alias = "ao-nu", seo_description = "Sản phẩm áo thời trang nữ", seo_title = "Sản phẩm áo thời trang women" },
                  new CategoryTranslation() { id = 4, category_id = 2, name = "Women Shirt", language_id = "en-US", seo_alias = "women-shirt", seo_description = "The shirt products for women", seo_title = "The shirt products for women" }
                    );

            modelBuilder.Entity<Product>().HasData(
           new Product()
           {
               id = 1,
               date_created = DateTime.Now,
               original_price = 100000,
               price = 200000,
               stock = 0,
               view_count = 0,
           });
            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation()
                 {
                     id = 1,
                     product_id = 1,
                     name = "Áo sơ mi nam trắng Việt Tiến",
                     languege_id = "vi-VN",
                     seo_alias = "ao-so-mi-nam-trang-viet-tien",
                     seo_description = "Áo sơ mi nam trắng Việt Tiến",
                     seo_title = "Áo sơ mi nam trắng Việt Tiến",
                     details = "Áo sơ mi nam trắng Việt Tiến",
                     description = "Áo sơ mi nam trắng Việt Tiến"
                 },
                    new ProductTranslation()
                    {
                        id = 2,
                        product_id = 1,
                        name = "Viet Tien Men T-Shirt",
                        languege_id = "en-US",
                        seo_alias = "viet-tien-men-t-shirt",
                        seo_description = "Viet Tien Men T-Shirt",
                        seo_title = "Viet Tien Men T-Shirt",
                        details = "Viet Tien Men T-Shirt",
                        description = "Viet Tien Men T-Shirt"
                    });
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { product_id = 1, category_id = 1 }
                );

            // any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "hcm.dutoang8@gmail.com",
                NormalizedEmail = "hcm.dutoang8@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                first_name = "Long",
                last_name = "Do",
                date_of_birth = new DateTime(2020, 01, 31)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
    
}
