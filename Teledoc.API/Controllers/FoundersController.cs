using Microsoft.AspNetCore.Mvc;
using Teledoc.Core.Services;
using Teledoc.DAL.Models;

namespace Teledoc.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FoundersController : TeledocController<Founder>
{
    public FoundersController(ServiceBase<Founder> service, ILogger<TeledocController<Founder>> logger) : base(service,
        logger)
    {
    }

    [HttpGet]
    [Route("getByInn")]
    public async Task<IActionResult> GetByInn(string inn)
        => Ok(await ((FounderService)_service).GetByInn(inn));
}