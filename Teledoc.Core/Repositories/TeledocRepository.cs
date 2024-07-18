using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Teledoc.DAL.Models;

namespace Teledoc.Core.Repositories;

public class TeledocRepository : EntityRepository<Client>
{
    public TeledocRepository(DbContext context, ILogger<EntityRepository<Client>> logger) : base(context, logger)
    {
    }
}