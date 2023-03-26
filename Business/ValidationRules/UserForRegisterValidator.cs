using Core.Entities.Concrete;
using Entity.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class UserForRegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.FirstName).MinimumLength(2);
            RuleFor(x => x.FirstName).MaximumLength(50);

            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.LastName).MinimumLength(2);
            RuleFor(x => x.LastName).MaximumLength(50);

            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).MinimumLength(2);
            RuleFor(x => x.Email).MaximumLength(50);

            RuleFor(x => x.Password).NotNull();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(5);
            RuleFor(x => x.Password).MaximumLength(16);

            RuleFor(x => x.Address).NotNull();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Address).MinimumLength(2);
            RuleFor(x => x.Address).MaximumLength(200);

            RuleFor(x => x.City).NotNull();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.City).MinimumLength(2);
            RuleFor(x => x.City).MaximumLength(50);

            RuleFor(x => x.Country).NotNull();
            RuleFor(x => x.Country).NotEmpty();
            RuleFor(x => x.Country).MinimumLength(2);
            RuleFor(x => x.Country).MaximumLength(50);

            RuleFor(x => x.Phone).NotNull();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.Phone).MinimumLength(2);
            RuleFor(x => x.Phone).MaximumLength(11);
        }
    }
}
