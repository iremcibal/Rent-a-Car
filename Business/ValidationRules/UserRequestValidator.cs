using Business.Constants;
using Business.Requests.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class UserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public UserRequestValidator()
        {
            RuleFor(r => r.FirstName).MinimumLength(2).NotEmpty().WithMessage(Messages.MustContainAtMinTwoChar);
            RuleFor(r => r.LastName).MinimumLength(2).NotEmpty().WithMessage(Messages.MustContainAtMinTwoChar);
            RuleFor(r => r.Email).NotEmpty().EmailAddress();
            RuleFor(r => r.NationalIdentity).Length(11).NotEmpty().WithMessage(Messages.PleaseEnterAValidNationalyIdNumber);

        }
    }
}
