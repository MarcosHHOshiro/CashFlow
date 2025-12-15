using CashFlow.Application.UseCase.Expenses.Register;
using CashFlow.Communication.Enums;
using CashFlow.Excetiom;
using CommonTestUtilities.Requests;
using Shouldly;

namespace Validators.Tests.Expenses.Expenses.Register;

public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.ShouldBeTrue();
    }

    [Fact]
    public void Error_Title_Empty()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Title = string.Empty;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(
            errors => errors.Single().ErrorMessage.ShouldBe(ResourceErrorMessages.TITLE_REQUIRED)
        );
    }

    [Fact]
    public void Error_Date_Future()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Date = DateTime.UtcNow.AddDays(1);

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(
            errors => errors.Single().ErrorMessage.ShouldBe(ResourceErrorMessages.EXPENSES_CANNOT_FOR_THE_FUTURE)
        );
    }

    [Fact]
    public void Error_Payment_Type_Invalid()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.PaymentType = (PaymentType)700;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(
            errors => errors.Single().ErrorMessage.ShouldBe(ResourceErrorMessages.PAYMENT_TYPE_INVALID)
        );
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-2)]
    [InlineData(-7)]
    public void Error_Amount_Invalid(decimal amount)
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Amount = amount;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(
            errors => errors.Single().ErrorMessage.ShouldBe(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO)
        );
    }

}

