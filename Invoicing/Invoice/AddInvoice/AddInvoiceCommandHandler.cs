
public record AddInvoiceCommand(InvoiceRecord InvoiceRecord)
    : ICommand<AddInvoiceResult>;
public record AddInvoiceResult(InvoiceRecord InvoiceRecord);

public class CheckoutBasketCommandValidator
    : AbstractValidator<AddInvoiceCommand>
{
    public CheckoutBasketCommandValidator()
    {
        RuleFor(x => x.InvoiceRecord).NotNull().WithMessage("InvoiceRecord can't be null");
        RuleFor(x => x.InvoiceRecord.CustomerName).NotEmpty().WithMessage("CustomerName is required");
    }
}

public class AddInvoiceCommandHandler
    (IUnitOfWork unitOfWork)
    : ICommandHandler<AddInvoiceCommand, AddInvoiceResult>
{
    public async Task<AddInvoiceResult> Handle(AddInvoiceCommand command, CancellationToken cancellationToken)
    {
        await unitOfWork.Invoices.AddAsync(command.InvoiceRecord);
        await unitOfWork.SaveAsync();

        return new AddInvoiceResult(command.InvoiceRecord);
    }
}