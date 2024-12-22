public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public IRepository<InvoiceRecord> Invoices { get; }
    public IRepository<AddInvoiceItemDto> InvoiceItems { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Invoices = new Repository<InvoiceRecord>(context);
        InvoiceItems = new Repository<AddInvoiceItemDto>(context);
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}
