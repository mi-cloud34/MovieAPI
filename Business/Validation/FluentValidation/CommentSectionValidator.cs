using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Validation.FluentValidation
{
    public class CommentSectionValidator:AbstractValidator<CommentSection>
    {
        public CommentSectionValidator()
        {
            RuleFor(p => p.Comment).NotEmpty();
            RuleFor(p => p.Comment).MinimumLength(4);
            RuleFor(p => p.UserId).NotEmpty();
           
            }

    
    }
}
