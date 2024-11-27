using si730ebu2019126668.API.Observability.Domain.Model.Aggregates;
using si730ebu2019126668.API.Shared.Domain.Repositories;

namespace si730ebu2019126668.API.Observability.Domain.Repositories;

public interface IThingStateRepository : IBaseRepository<ThingState>
{
    Task<bool> ExistsByThingSerialNumberAndCollectedAtAsync(String thingSerialNumber, DateTime collectedAt);
}