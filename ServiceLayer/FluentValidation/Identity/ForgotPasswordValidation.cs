using EntityLayer.Identity.ViewModels;
using FluentValidation;
using ServiceLayer.Messages.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.Identity
{
    public class ForgotPasswordValidation : AbstractValidator<ForgotPasswordVM>
    {
        public ForgotPasswordValidation()
        {
            RuleFor(x => x.Email)
               .NotEmpty()
           .NotNull()
               .EmailAddress().WithMessage(Identitymessages.CheckEmailAddress("Email"));
        }
    }
}
