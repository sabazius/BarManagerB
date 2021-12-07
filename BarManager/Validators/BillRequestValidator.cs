using System;
using System.Data;
using BarManager.Models.Requests;
using FluentValidation;

namespace BarManager.Validators
{
    public class BillRequestValidator : AbstractValidator<BillRequest>
    {
        public BillRequestValidator()
        {
            RuleFor(x => x.Amount).GreaterThan(0);
            RuleFor(x => x.BillStatus).NotEmpty().IsInEnum();
            RuleFor(x => x.Created).LessThan(x => x.Finished);
            RuleFor(x => x.Finished).GreaterThanOrEqualTo(x => x.Created);
            RuleFor(x => x.PaymentType).NotEmpty().IsInEnum();

        }

    }
}
