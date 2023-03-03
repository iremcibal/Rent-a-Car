using Business.Constants;
using Business.Requests.Brands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class BrandRequestValidator :AbstractValidator<CreateBrandRequest>
    {
        public BrandRequestValidator()
        {
            RuleFor(r => r.Name).MinimumLength(2).NotEmpty().WithMessage(Messages.MustContainAtMinTwoChar);

        }
    }
}
