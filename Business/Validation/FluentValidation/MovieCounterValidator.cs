using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Validation.FluentValidation
{
    public class MovieCountryValidator:AbstractValidator<MovieCountry>
    {
        public MovieCountryValidator()
        {

            RuleFor(p => p.CountryName).NotEmpty();
            RuleFor(p => p.CountryName).MinimumLength(2);
            }
    }
}
