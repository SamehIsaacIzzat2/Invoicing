namespace Invoicing.Api.Exceptions;

public class InvoiceNotFoundException : NotFoundException
{
    public InvoiceNotFoundException(string userName) : base("Invoice", userName)
    {

    }
}