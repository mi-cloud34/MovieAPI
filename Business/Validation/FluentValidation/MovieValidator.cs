using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Validation.FluentValidation
{
    public class MovieValidator:AbstractValidator<Movie>
    {
        public MovieValidator()
        {

            RuleFor(p => p.MovieName).NotEmpty();
            RuleFor(p => p.MovieName).MinimumLength(5);
            RuleFor(p => p.MovieBudget).NotEmpty();


        }
    }
}
