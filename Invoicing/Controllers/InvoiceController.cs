
using Invoicing.Api.Dto;
using Invoicing.API.Invoice.GetInvoice;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

[Route("api/[controller]")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly ISender sender;

    public InvoiceController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateInvoice(AddInvoiceRequest request)
    {
        var command = request.Adapt<AddInvoiceCommand>();

        var result = await sender.Send(command);

        var response = result.Adapt<AddInvoiceResponse>();
         
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateInvoice(UpdateInvoiceRequest request)
    {
        var command = request.Adapt<UpdateInvoiceCommand>();

        var result = await sender.Send(command);

        var response = result.Adapt<UpdateInvoiceResponse>();

        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteInvoice(DeleteInvoiceRequest request)
    {
        var command = request.Adapt<DeleteInvoiceCommand>();

        var result = await sender.Send(command);

        return Ok(new DeleteInvoiceResponse(result.success));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetInvoice(int id)
    {
        var qry = new GetInvoiceQuery(id);

        var result = await sender.Send(qry);

        var response = result.Adapt<GetInvoiceResponse>();

        return Ok(response);
    }

    [HttpGet()]
    public async Task<IActionResult> GetInvoices()
    {
        var qry = new GetInvoicesQuery();

        var result = await sender.Send(qry);

        var response = result.Adapt<GetInvoicesResponse>();

        return Ok(response);
    }
}

public record GetInvoiceRequest(int Id);
public record GetInvoiceResponse(InvoiceDto InvoiceRecord);

public record AddInvoiceRequest(AddInvoiceDto InvoiceRecord);
public record AddInvoiceResponse(InvoiceDto InvoiceRecord);

public record UpdateInvoiceRequest(UpdateInvoiceDto InvoiceRecord);
public record UpdateInvoiceResponse(InvoiceDto InvoiceRecord);

public record DeleteInvoiceRequest(int Id);
public record DeleteInvoiceResponse(bool success);


public record GetInvoicesResponse(List<InvoiceDto> InvoiceRecords);