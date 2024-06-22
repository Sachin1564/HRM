using EntityLayer.Identity.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Components.Forms;
using ServiceLayer.Messages.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.Identity
{
    public class SignUpValidation : AbstractValidator<SignUpVM>
    {
        public SignUpValidation()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Email)
                .NotEmpty()
            .NotNull()
                .EmailAddress().WithMessage(Identitymessages.CheckEmailAddress("Email"));
            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .NotNull()
                .Equal(x => x.Password).WithMessage(Identitymessages.ComaparePassword());
        }
    }
}
