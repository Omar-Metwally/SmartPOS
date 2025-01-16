using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartPOS.Core.Features.Branches.Commands.Models;


namespace SmartPOS.WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class BranchesController : AppControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateBranch([FromBody] AddBranchCommandModel request)
    {
        var response = await Mediator.Send(request);
        var apiResult = response.ToApiResult();
        return StatusCode(apiResult.StatusCode, apiResult);
    }

}
