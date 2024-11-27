using Microsoft.EntityFrameworkCore;
using si730ebu2019126668.API.Observability.Domain.Model.Aggregates;
using si730ebu2019126668.API.Observability.Domain.Repositories;
using si730ebu2019126668.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebu2019126668.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730ebu2019126668.API.Observability.Infrastructure.Persistence.EFC.Repositories;

public class ThingStateRepository(AppDbContext context) : BaseRepository<ThingState>(context), IThingStateRepository
{
    public async Task<bool> ExistsByThingSerialNumberAndCollectedAtAsync(string thingSerialNumber, DateTime collectedAt)
    {
        return await Context.Set<ThingState>().AnyAsync(ts =>
            ts.ThingSerialNumber.SerialNumber == thingSerialNumber 
            && 
            ts.CollectedAt == collectedAt);
    }
}