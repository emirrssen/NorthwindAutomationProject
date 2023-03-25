using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x.ProductId).NotNull();
            RuleFor(x => x.CustomerId).NotNull();
            RuleFor(x => x.EmployeeId).NotNull();
            RuleFor(x => x.OrderDate).NotNull();
            RuleFor(x => x.OrderDate).LessThanOrEqualTo(DateTime.Today);
        }
    }
}
