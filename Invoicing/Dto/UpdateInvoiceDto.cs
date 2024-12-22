namespace Invoicing.Api.Dto
{
    public class UpdateInvoiceDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public ICollection<UpdateInvoiceItemDto> Items { get; set; }
    }
}
