
public record UpdateInvoiceCommand(InvoiceRecord InvoiceRecord)
    : ICommand<UpdateInvoiceResult>;
public record UpdateInvoiceResult(InvoiceRecord InvoiceRecord);

public class UpdateInvoiceCommandValidator
    : AbstractValidator<AddInvoiceCommand>
{
    public UpdateInvoiceCommandValidator()
    {
        RuleFor(x => x.InvoiceRecord).NotNull().WithMessage("InvoiceRecord can't be null");
        RuleFor(x => x.InvoiceRecord.CustomerName).NotEmpty().WithMessage("CustomerName is required");
    }
}

public class UpdateInvoiceInvoiceCommandHandler
    (IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateInvoiceCommand, UpdateInvoiceResult>
{
    public async Task<UpdateInvoiceResult> Handle(UpdateInvoiceCommand command, CancellationToken cancellationToken)
    {
        await unitOfWork.Invoices.UpdateAsync(command.InvoiceRecord);
        await unitOfWork.SaveAsync();

        return new UpdateInvoiceResult(command.InvoiceRecord);
    }
}