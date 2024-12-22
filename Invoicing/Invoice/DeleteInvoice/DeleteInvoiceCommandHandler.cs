
public record DeleteInvoiceCommand(int Id)
    : ICommand<DeleteInvoiceResult>;
public record DeleteInvoiceResult(bool success);

public class DeleteInvoiceCommandValidator
    : AbstractValidator<AddInvoiceCommand>
{
    public DeleteInvoiceCommandValidator()
    {
         
    }
}

public class DeleteInvoiceInvoiceCommandHandler
    (IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteInvoiceCommand, DeleteInvoiceResult>
{
    public async Task<DeleteInvoiceResult> Handle(DeleteInvoiceCommand command, CancellationToken cancellationToken)
    {
        await unitOfWork.Invoices.DeleteAsync(command.Id);
        await unitOfWork.SaveAsync();

        return new DeleteInvoiceResult(true);
    }
}