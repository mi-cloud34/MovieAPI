﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Validation.FluentValidation
{
    public class MovieLanguageValidator:AbstractValidator<MovieLanguage>
    {
        public MovieLanguageValidator()
        {

            RuleFor(p => p.LanguageName).NotEmpty();
            RuleFor(p => p.LanguageName).MinimumLength(2);
            RuleFor(p => p.Id).NotEmpty();
           }
    }
}
