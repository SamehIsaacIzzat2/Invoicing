namespace Invoicing.Api.Models
{
    public class AddInvoiceDto
    {
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public ICollection<AddInvoiceItemDto> Items { get; set; }
    }
}
