using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Validation.FluentValidation
{
    public class MovieDirectorValidator:AbstractValidator<MovieDirector>
    {
        public MovieDirectorValidator()
        {

            RuleFor(p => p.DirectorName).NotEmpty();
            RuleFor(p => p.DirectorName).MinimumLength(2);
           }
    }
}
