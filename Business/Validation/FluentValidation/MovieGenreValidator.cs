using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Validation.FluentValidation
{
    public class MovieGenreValidator:AbstractValidator<MovieGenre>
    {
        public MovieGenreValidator()
        {

            RuleFor(p => p.GenreName).NotEmpty();
            RuleFor(p => p.GenreName).MinimumLength(2);
            RuleFor(p => p.Id).NotEmpty();
           }
    }
}
