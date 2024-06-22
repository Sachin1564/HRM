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
    public class LogInValidation : AbstractValidator<LogInVM>
    {
        public LogInValidation()
        {
            RuleFor(x => x.Email)
               .NotEmpty()
           .NotNull()
               .EmailAddress().WithMessage(Identitymessages.CheckEmailAddress("Email"));
            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.RememberMe)
               .NotEmpty()
               .NotNull();
        }
    }
}
