using System.Runtime.CompilerServices;

namespace CashFlow.Communication.Responses;

public class ResponseErrorJson
{
    public List<string> ErrorsMessage { get; set; }

    public ResponseErrorJson(string errorMessages)
    {
        ErrorsMessage = [errorMessages];
    }

    public ResponseErrorJson(List<string> errorMessages)
    {
        ErrorsMessage = errorMessages;
    }
}
