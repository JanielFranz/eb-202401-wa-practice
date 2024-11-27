using si730ebu2019126668.API.Inventory.Domain.Model.Aggregates;
using si730ebu2019126668.API.Inventory.Interfaces.REST.Resources;

namespace si730ebu2019126668.API.Inventory.Interfaces.REST.Transform;

public static class ThingResourceFromEntityAssembler
{
    public static ThingResource ToResourceFromEntity(Thing entity)
    {
        return new ThingResource(entity.Id, entity.SerialNumber.GetSerialNumberAsString(), entity.Model
            , entity.OperationMode.ToString(), entity.MaximumTemperatureThreshold,
            entity.MinimumHumidityThreshold);
    }
}