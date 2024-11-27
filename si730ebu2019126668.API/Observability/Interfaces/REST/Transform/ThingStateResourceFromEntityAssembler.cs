using si730ebu2019126668.API.Observability.Domain.Model.Aggregates;
using si730ebu2019126668.API.Observability.Interfaces.REST.Resources;

namespace si730ebu2019126668.API.Observability.Interfaces.REST.Transform;

public static class ThingStateResourceFromEntityAssembler
{
    public static ThingStateResource ToResourceFromEntity(ThingState entity)
    {
        return new ThingStateResource(entity.Id, entity.ThingSerialNumber.SerialNumber
            , entity.CurrentOperationMode, entity.CurrentTemperature, entity.CurrentHumidity
            , entity.CollectedAt);
    }
}