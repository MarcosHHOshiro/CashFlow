using CashFlow.Application.UseCase.Expenses.Register;
using CashFlow.Communication.Requests;

namespace Validators.Tests.Expenses.Expenses.Register;

public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = 

        //Act
        var result = validator.Validate(request);

        //Assert
        Assert.True(result.IsValid);
    }
}

