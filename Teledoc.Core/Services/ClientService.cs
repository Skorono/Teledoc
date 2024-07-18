using Teledoc.Core.Exceptions.Validation;
using Teledoc.Core.Repositories;
using Teledoc.DAL.Models;

namespace Teledoc.Core.Services;

public class ClientService : ServiceBase<Client>
{
    public ClientService(EntityRepository<Client> repository) : base(repository)
    {
    }

    public async Task<IEnumerable<Founder>?> GetClientFounders(int id)
    {
        return (await GetById(id)).Founders;
    }

    public async Task<IEnumerable<Founder>?> GetClientFounders(Client client)
    {
        return await GetClientFounders(client.Id);
    }
    
    public async Task AddClientFounders(int id, IEnumerable<Founder> founders)
    {
        var client = _repository.Get(id);

        
        founders.Select(f => client.Founders.Append(f));

        await _repository.UpdateAsync(client);
    }

    public override Task Add(Client entity)
    {
        Validate(entity);
        return base.Add(entity);
    }

    public override Task Update(Client entity)
    {
        Validate(entity);
        return base.Update(entity);
    }

    private void Validate(Client client)
    {
        if (client.Type!.Name == ClientType.Types.IndividualEntrepreneur && client.Founders.Count() > 1)
            throw new ClientValidationException($"Client type {client.Type!.Name} cannot have more than one founder");
    }
}