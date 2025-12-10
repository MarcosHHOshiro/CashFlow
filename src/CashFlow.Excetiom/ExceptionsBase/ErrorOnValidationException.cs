using System.Security.Cryptography.X509Certificates;

namespace CashFlow.Excetiom.ExceptionsBase;

public class ErrorOnValidationException : CashFlowException
{
    public List<string> Errors { get; set; }

    public ErrorOnValidationException(List<string> errorMessages)
    {
        Errors = errorMessages;
    }
}
 