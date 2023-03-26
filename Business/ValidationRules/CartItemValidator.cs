using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CartItemValidator : AbstractValidator<CartItem>
    {
        public CartItemValidator()
        {
            RuleFor(x => x.ProductId).NotNull();
            RuleFor(x => x.ProductId).NotEmpty();

            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.UserId).NotEmpty();

            RuleFor(x => x.Quantity).NotEmpty();
            RuleFor(x => x.Quantity).NotNull();
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(1);
        }
    }
}
