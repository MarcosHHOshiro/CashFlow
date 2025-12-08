using CashFlow.Communication.Requests;
using FluentValidation;
using FluentValidation.Validators;

namespace CashFlow.Application.UseCase.Expenses.Register;

public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpenseValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage("The title is required");
        RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage("The amount must be greater than zero");
        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("The amount must be greater than zero");
        RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage("The PaymentType is not valid");
    }
}

