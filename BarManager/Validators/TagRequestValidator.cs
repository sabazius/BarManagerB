using System;
using System.Data;
using BarManager.Models.Requests;
using FluentValidation;

namespace BarManager.Validators
{
    public class TagRequestValidator : AbstractValidator<TagRequest>
    {
        public TagRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(2).MaximumLength(10);
        }

    }
}
