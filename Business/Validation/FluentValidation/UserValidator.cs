using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {

            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.Email).MinimumLength(2);
            RuleFor(p => p.FirstName).NotEmpty();
           }
    }
}
