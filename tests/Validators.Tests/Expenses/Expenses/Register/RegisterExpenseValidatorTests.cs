using CashFlow.Application.UseCase.Expenses.Register;
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

    public void Failure() { 
    
    }
}

