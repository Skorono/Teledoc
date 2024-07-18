using Microsoft.AspNetCore.Mvc;
using Teledoc.Core.Services;
using Teledoc.DAL.Models;

namespace Teledoc.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : TeledocController<Client>
{
    public ClientsController(ServiceBase<Client> service, ILogger<ClientsController> logger) : base(service, logger)
    {
    }

    [HttpGet]
    [Route("getFounders")]
    public async Task<IEnumerable<Founder>> GetFounders(int clientId)
    {
        return (await _service.GetById(clientId)).Founders;
    }
}