namespace Invoicing.Api.Models
{
    public class InvoiceRecord
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public ICollection<InvoiceItem> Items { get; set; }
    }
}
