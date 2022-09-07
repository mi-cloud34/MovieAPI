using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Validation.FluentValidation
{
    public class SectionActorValidator:AbstractValidator<SectionActor>
    {
        public SectionActorValidator()
        {
            RuleFor(p => p.ActorName).NotEmpty();
            RuleFor(p => p.ActorName).MinimumLength(2);
            RuleFor(p => p.Gender).NotEmpty();
           }

   
    }
}
