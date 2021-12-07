using BarManager.Models.Requests;
using FluentValidation;

namespace BarManager.Validators
{
    public class EmployeeRequestValidator : AbstractValidator<EmployeeRequest>
    {
        public EmployeeRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(2).MaximumLength(10);
            RuleFor(x => x.Type).IsInEnum();
        }
    }
}
