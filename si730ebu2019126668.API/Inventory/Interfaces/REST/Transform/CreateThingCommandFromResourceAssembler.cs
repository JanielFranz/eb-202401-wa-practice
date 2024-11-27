using si730ebu2019126668.API.Inventory.Domain.Model.Commands;
using si730ebu2019126668.API.Inventory.Interfaces.REST.Resources;

namespace si730ebu2019126668.API.Inventory.Interfaces.REST.Transform;

public static class CreateThingCommandFromResourceAssembler
{
    public static CreateThingCommand ToCommandFromResource(CreateThingResource resource)
    {
        return new CreateThingCommand(resource.Model, resource.MaximumTemperatureThreshold,
            resource.MinimumHumidityThreshold);
    }
}