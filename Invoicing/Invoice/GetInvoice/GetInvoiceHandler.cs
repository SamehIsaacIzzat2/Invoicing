namespace Invoicing.API.Invoice.GetInvoice;

public record GetInvoiceQuery(int Id) : IQuery<GetInvoiceResult>;
public record GetInvoiceResult(InvoiceRecord InvoiceRecord);

public class GetInvoiceQueryHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetInvoiceQuery, GetInvoiceResult>
{
    public async Task<GetInvoiceResult> Handle(GetInvoiceQuery query, CancellationToken cancellationToken)
    {
        var invoice = await unitOfWork.Invoices.GetByIdAsync(query.Id);

        return new GetInvoiceResult(invoice);
    }
}