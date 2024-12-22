namespace Invoicing.Api.Dto
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public ICollection<InvoiceItemDto> Items { get; set; }
    }
}
