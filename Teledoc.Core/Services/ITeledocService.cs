using Teledoc.DAL.Models;

namespace Teledoc.Core.Services;

public interface ITeledocService
{
    public Task<IEnumerable<Client>> GetClients();

    public Task<IEnumerable<Founder>> GetClientFounders(int id);

    public Task<IEnumerable<Founder>> GetClientFounders(Client client);

    public Task AddClient(Client client);

    public Task AddClientFounders(int id, IEnumerable<Founder> founders);

    public Task UpdateClient(Client client);

    public Task RemoveClient(Client client);
}