public interface IUnitOfWork : IDisposable
{
    IRepository<InvoiceRecord> Invoices { get; }
    IRepository<AddInvoiceItemDto> InvoiceItems { get; }
    Task SaveAsync();
}
