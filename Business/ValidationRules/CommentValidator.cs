using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.UserId).NotNull();

            RuleFor(x => x.ProductId).NotNull();
            RuleFor(x => x.ProductId).NotEmpty();

            RuleFor(x => x.CommentContent).NotEmpty();
            RuleFor(x => x.CommentContent).NotNull();
            RuleFor(x => x.CommentContent).MinimumLength(50);
            RuleFor(x => x.CommentContent).MaximumLength(5000);
        }
    }
}
