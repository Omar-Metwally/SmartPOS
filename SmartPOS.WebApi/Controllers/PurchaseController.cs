using Microsoft.AspNetCore.Mvc;
using SmartPOS.Core.Features.Branches.Commands.Models;
using SmartPOS.Core.Features.Purchase.Commands.Models;

namespace SmartPOS.WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class PurchaseController : AppControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePurchase([FromBody] AddPurchaseCommandModel request)
    {
        var response = await Mediator.Send(request);
        var apiResult = response.ToApiResult();
        return StatusCode(apiResult.StatusCode, apiResult);
    }
}
