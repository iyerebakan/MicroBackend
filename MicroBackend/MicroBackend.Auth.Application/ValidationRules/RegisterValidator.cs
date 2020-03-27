using FluentValidation;
using MicroBackend.Auth.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Auth.Application.ValidationRules
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(k => k.Email).NotEmpty().WithMessage("Email address can not be empty..!");
            RuleFor(k => k.UserName).NotEmpty().WithMessage("User name can not be empty..!");
            RuleFor(k => k.Password).NotEmpty().WithMessage("Password can not be empty..!");
        }
    }
}
