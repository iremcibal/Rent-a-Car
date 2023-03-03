using Business.Constants;
using Business.Requests.Cars;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CarRequestValidator : AbstractValidator<CreateCarRequest>
    {
        public CarRequestValidator() 
        {
            RuleFor(r=>r.Name).MinimumLength(2).NotEmpty().WithMessage(Messages.MustContainAtMinTwoChar);
            RuleFor(r => r.DailyPrice).GreaterThan(0).NotEmpty().WithMessage(Messages.MustBeGreaterThanZero);
        }
    }
}
