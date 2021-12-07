using System;
using System.Data;
using BarManager.Models.Requests;
using FluentValidation;

namespace BarManager.Validators
{
    public class ClientRequestValidator : AbstractValidator<ClientRequest>
    {
        public ClientRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(2).MaximumLength(10);
            RuleFor(x => x.MoneySpend).NotNull().NotEmpty();
            RuleFor(x => x.Discount).NotNull().InclusiveBetween(0, 100);
        }

    }
}
