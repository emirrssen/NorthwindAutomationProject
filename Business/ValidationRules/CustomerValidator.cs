using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty();
            RuleFor(x => x.CompanyName).NotNull();
            RuleFor(x => x.CompanyName).MinimumLength(2);
            RuleFor(x => x.CompanyName).MaximumLength(40);

            RuleFor(x => x.ContactName).NotEmpty();
            RuleFor(x => x.ContactName).NotNull();
            RuleFor(x => x.ContactName).MinimumLength(2);
            RuleFor(x => x.ContactName).MaximumLength(30);

            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Address).NotNull();
            RuleFor(x => x.Address).MinimumLength(2);
            RuleFor(x => x.Address).MaximumLength(60);

            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.City).NotNull();
            RuleFor(x => x.City).MinimumLength(2);
            RuleFor(x => x.City).MaximumLength(15);

            RuleFor(x => x.Country).NotEmpty();
            RuleFor(x => x.Country).NotNull();
            RuleFor(x => x.Country).MinimumLength(2);
            RuleFor(x => x.Country).MaximumLength(15);

            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.Phone).NotNull();
            RuleFor(x => x.Phone).MinimumLength(2);
            RuleFor(x => x.Phone).MaximumLength(24);
        }
    }
}
