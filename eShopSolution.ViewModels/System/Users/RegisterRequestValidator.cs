﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace eShopSolution.ViewModels.System.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FistName).NotEmpty().WithMessage("First name is required")
                .MaximumLength(200).WithMessage("First name can not over 200 characters");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required")
                .MaximumLength(200).WithMessage("Last name can not over 200 characters");

            RuleFor(x => x.DoB).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Birthday can not greater then 100 years");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("email format not match");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password is at least 8 characters")
                .MaximumLength(16).WithMessage("Password is at most 8 characters");

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPass)
                {
                    context.AddFailure("Confirm password is not match");
                }
            });
        }
    }
}