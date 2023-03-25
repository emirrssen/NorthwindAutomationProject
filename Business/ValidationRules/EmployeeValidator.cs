using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.LastName).MinimumLength(2);
            RuleFor(x => x.LastName).MaximumLength(20);

            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.FirstName).MinimumLength(2);
            RuleFor(x => x.FirstName).MaximumLength(10);

            RuleFor(x => x.Title).NotNull();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Title).MinimumLength(2);
            RuleFor(x => x.Title).MaximumLength(30);

            RuleFor(x => x.BirthDate).LessThan(DateTime.Today);

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
