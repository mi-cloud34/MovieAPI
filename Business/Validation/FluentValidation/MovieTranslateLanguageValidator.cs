using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Validation.FluentValidation
{
    public class MovieTranslateLanguageValidator:AbstractValidator<MovieTranslateLanguage>
    {
        public MovieTranslateLanguageValidator()
        {

            RuleFor(p => p.TranslateLanguageName).NotEmpty();
            RuleFor(p => p.TranslateLanguageName).MinimumLength(2);
            RuleFor(p => p.Id).NotEmpty();
            }
    }
}
