using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty();
            RuleFor(x => x.CategoryName).NotNull();
            RuleFor(x => x.CategoryName).MinimumLength(2);
            RuleFor(x => x.CategoryName).MaximumLength(15);
        }
    }
}
