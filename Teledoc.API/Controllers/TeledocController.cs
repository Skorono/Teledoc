using Microsoft.AspNetCore.Mvc;
using Teledoc.Core.Services;

namespace Teledoc.API.Controllers;

public abstract class TeledocController<T> : ControllerBase
    where T : class
{
    protected readonly ServiceBase<T> _service;
    protected ILogger<TeledocController<T>> _logger;

    public TeledocController(ServiceBase<T> service, ILogger<TeledocController<T>> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    [Route("get")]
    public virtual async Task<IEnumerable<T>> Get()
    {
        return await _service.Get();
    }
    
        
    [HttpGet]
    [Route("getById")]
    public virtual async Task<IActionResult> GetById(int entityId)
    {
        T? entity = await _service.GetById(entityId);
        return entity != null ? Ok(entity) : NotFound();
    }

    [HttpPost]
    [Route("add")]
    public virtual  async Task<IActionResult> Add(T entity)
    {
        await _service.Add(entity);
        return Ok();
    }

    [HttpPost]
    [Route("update")]
    public virtual  async Task<IActionResult> Update(T client)
    {
        await _service.Update(client);
        return Ok();
    }

    [HttpDelete]
    [Route("delete")]
    public virtual  async Task<IActionResult> Delete(int entityId)
    {
        await _service.Remove(entityId);
        return Ok();
    }
}