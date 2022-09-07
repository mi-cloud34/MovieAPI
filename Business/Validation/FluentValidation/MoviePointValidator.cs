using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Validation.FluentValidation
{
    public class MoviePointValidator:AbstractValidator<MoviePoint>
    {
        public MoviePointValidator()
        {

            RuleFor(p => p.Point).NotEmpty();
            RuleFor(p => p.Point).GreaterThan(0);
            RuleFor(p => p.Id).NotEmpty();
            }
    }
}
