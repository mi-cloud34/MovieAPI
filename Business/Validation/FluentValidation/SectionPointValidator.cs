using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Validation.FluentValidation
{
    public class SectionPointValidator:AbstractValidator<SectionPoint>
    {
        public SectionPointValidator()
        {

            RuleFor(p => p.Point).NotEmpty();
            RuleFor(p => p.Point).GreaterThan(0);
           }
    }
}
