using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class ReplyValidator : AbstractValidator<Reply>
    {
        public ReplyValidator()
        {
            RuleFor(x => x.CommentId).NotNull();
            RuleFor(x => x.CommentId).NotEmpty();

            RuleFor(x => x.ReplyContent).NotEmpty();
            RuleFor(x => x.ReplyContent).NotNull();
            RuleFor(x => x.ReplyContent).MinimumLength(50);
            RuleFor(x => x.ReplyContent).MaximumLength(5000);
        }
    }
}
