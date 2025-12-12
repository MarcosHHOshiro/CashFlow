using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CommonTestUtilities.Requests;

public class RequestRegisterExpenseJsonBuilder
{
    public RequestRegisterExpenseJson Build()
    {
        var faker = new Faker();

        var request = new RequestRegisterExpenseJson
        { 
            Title = faker.Commerce.Product(),
            Date = faker.Date.Past(),
            Description = faker.Commerce.ProductDescription(),
            PaymentType = faker.PickRandom<PaymentType>(),
            Amount = faker.Random.Decimal(min:1, max: 1000),
        };

        return request;
    }
}

