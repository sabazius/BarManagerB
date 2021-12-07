using BarManager.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarManager.Validators
{
    public class OrderItemValidator : AbstractValidator<OrderItemRequest>
    {
        public OrderItemValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Type).IsInEnum();
            RuleForEach(x => x.Tags).NotNull().NotEmpty();
        }
    }
}
