using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Validation.FluentValidation
{
    public class SectionValidator:AbstractValidator<Section>
    {
        public SectionValidator()
        {

            RuleFor(p => p.SectionName).NotEmpty();
            RuleFor(p => p.SectionName).MinimumLength(2);
            RuleFor(p => p.SectionBudget).NotEmpty();
           }
    }
}
