using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Validation.FluentValidation
{
    public class LikeMovieValidator:AbstractValidator<LikeMovie>
    {
        public LikeMovieValidator()
        {

            RuleFor(p => p.Like).NotEmpty();
            RuleFor(p => p.Like).GreaterThan(0);
            RuleFor(p => p.UserId).NotEmpty();
           }
    }
}
