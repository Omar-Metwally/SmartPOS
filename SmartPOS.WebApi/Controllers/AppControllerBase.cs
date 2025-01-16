using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace SmartPOS.WebApi.Controllers;

public class AppControllerBase : ControllerBase
{
    private IMediator _mediatorInstance;
    protected IMediator Mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();

}