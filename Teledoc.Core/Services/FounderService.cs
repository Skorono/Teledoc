using Teledoc.Core.Exceptions.Validation;
using Teledoc.Core.Repositories;
using Teledoc.DAL.Models;

namespace Teledoc.Core.Services;

public class FounderService : ServiceBase<Founder>
{
    public FounderService(EntityRepository<Founder> repository) : base(repository)
    {
    }

    public async Task<Founder?> GetByInn(string inn)
        => (await _repository.GetAsync(f => f.Inn == inn))?.First();
}