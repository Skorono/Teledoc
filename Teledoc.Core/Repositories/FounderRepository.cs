using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Teledoc.DAL.Models;

namespace Teledoc.Core.Repositories;

public class FounderRepository : EntityRepository<Founder>
{
    public FounderRepository(DbContext context, ILogger<EntityRepository<Founder>> logger) : base(context, logger)
    {
    }

    public override IEnumerable<Founder> Get()
    {
        return DbSet
            .Include(f => f.Clients)
            .AsNoTracking();
    }
}