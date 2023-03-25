using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotNull();
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.ProductName).MinimumLength(2);
            RuleFor(x => x.ProductName).MaximumLength(40);

            RuleFor(x => x.CategoryId).NotNull();
            RuleFor(x => x.CategoryId).NotEmpty();

            RuleFor(x => x.QuantityPerUnit).NotNull();
            RuleFor(x => x.QuantityPerUnit).NotEmpty();
            RuleFor(x => x.QuantityPerUnit).MinimumLength(2);
            RuleFor(x => x.QuantityPerUnit).MaximumLength(20);

            RuleFor(x => x.UnitPrice).NotNull();
            RuleFor(x => x.UnitPrice).NotEmpty();

            RuleFor(x => x.UnitsInStock).NotNull();
            RuleFor(x => x.UnitsInStock).NotEmpty();
        }
    }
}
