namespace Invoicing.Api.Models
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public InvoiceRecord Invoice { get; set; }
    }
}
