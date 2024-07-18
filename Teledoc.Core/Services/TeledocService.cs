using Teledoc.Core.Repositories;
using Teledoc.DAL.Models;

namespace Teledoc.Core.Services;

public class TeledocService : ITeledocService
{
    private readonly EntityRepository<Client> _repository;

    public TeledocService(EntityRepository<Client> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Client>> GetClients()
    {
        return await _repository.GetAsync();
    }

    public async Task<IEnumerable<Founder>> GetClientFounders(int id)
    {
        var result = await _repository.GetAsync(id);
        return result.Founders;
    }


    public Task<IEnumerable<Founder>> GetClientFounders(Client client)
    {
        throw new NotImplementedException();
    }

    public async Task AddClient(Client client)
    {
        client.Type = null;
        await _repository.AddAsync(client);
    }

    public async Task AddClientFounders(int id, IEnumerable<Founder> founders)
    {
        var client = _repository.Get(id);
        client.Founders.Union(founders);
        // TODO validation before adding founders

        await _repository.UpdateAsync(client);
    }

    public async Task UpdateClient(Client client)
    {
        await _repository.UpdateAsync(client);
    }

    public Task RemoveClient(Client client)
    {
        throw new NotImplementedException();
    }
}