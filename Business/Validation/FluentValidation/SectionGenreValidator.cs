using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Validation.FluentValidation
{
    public class SectionGenreValidator:AbstractValidator<SectionGenre>
    {
        public SectionGenreValidator()
        {
            RuleFor(p => p.GenreName).NotEmpty();
            RuleFor(p => p.GenreName).MinimumLength(2);
           }
    }
}
