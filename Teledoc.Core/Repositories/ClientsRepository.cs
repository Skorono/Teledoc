using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Teledoc.Core.Exceptions.Entities;
using Teledoc.DAL.Models;

namespace Teledoc.Core.Repositories;

public class ClientsRepository : EntityRepository<Client>
{
    public ClientsRepository(DbContext context, ILogger<EntityRepository<Client>> logger) : base(context, logger)
    {
    }

    public override IEnumerable<Client> Get()
    {
        return DbSet
            .IgnoreAutoIncludes()
            .Include(c => c.Founders)
            .Include(c => c.Type);
    }

    public override Client Get(int id)
    {
        return Get().Single(c => c.Id == id)
               ?? throw new EntityNotFound("Failed to find entity");
    }
}