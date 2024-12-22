namespace Invoicing.Api.Dto
{
    public class UpdateInvoiceItemDto
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}
