namespace Invoicing.API.Invoice.GetInvoice;

public record GetInvoicesQuery() : IQuery<GetInvoicesResult>;
public record GetInvoicesResult(List<InvoiceRecord> InvoiceRecords);

public class GetInvoicesQueryHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetInvoicesQuery, GetInvoicesResult>
{
    public async Task<GetInvoicesResult> Handle(GetInvoicesQuery query, CancellationToken cancellationToken)
    {
        var invoices = await unitOfWork.Invoices.GetAllAsync();

        return new GetInvoicesResult(invoices.ToList());
    }
}