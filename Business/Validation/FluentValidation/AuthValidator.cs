using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class AuthValidator:AbstractValidator<User>
    {
        public AuthValidator()
        {

            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.FirstName).MinimumLength(5);
            RuleFor(p => p.Id).NotEmpty();
            }
    }
}
