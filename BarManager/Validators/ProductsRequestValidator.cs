using System;
using System.Data;
using BarManager.Models.Requests;
using FluentValidation;

namespace BarManager.Validators
{
    public class ProductsRequestValidator : AbstractValidator<ProductsRequest>
    {
        public ProductsRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(2).MaximumLength(10);
            RuleFor(x => x.Price).NotNull().NotEmpty();
        }

    }
}
