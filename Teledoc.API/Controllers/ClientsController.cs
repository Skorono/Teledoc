using Microsoft.AspNetCore.Mvc;
using Teledoc.Core.Services;
using Teledoc.DAL.Models;

namespace Teledoc.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly ITeledocService _service;
    private ILogger<ClientsController> _logger;

    public ClientsController(ITeledocService service, ILogger<ClientsController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    [Route("getAll")]
    public async Task<IEnumerable<Client>> GetAll()
    {
        return await _service.GetClients();
    }


    [HttpGet]
    [Route("getById")]
    public async Task<Client> GetById(int id)
    {
        return (await _service.GetClients()).First();
    }

    [HttpPost]
    [Route("add")]
    public async Task Add(Client client)
    {
        await _service.AddClient(client);
    }


    [HttpPost]
    [Route("update")]
    public async Task Update(Client client)
    {
        await _service.UpdateClient(client);
    }

    [HttpDelete]
    [Route("delete")]
    public async Task Delete(Client client)
    {
        await _service.RemoveClient(client);
    }
}