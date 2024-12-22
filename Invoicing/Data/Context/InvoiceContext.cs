using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<InvoiceRecord> Invoices { get; set; }
    public DbSet<InvoiceItem> InvoiceItems { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InvoiceRecord>()
            .HasMany(i => i.Items)
            .WithOne(ii => ii.Invoice)
            .HasForeignKey(ii => ii.InvoiceId);
    }
}
