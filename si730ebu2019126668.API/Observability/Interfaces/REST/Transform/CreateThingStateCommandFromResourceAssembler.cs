using si730ebu2019126668.API.Observability.Domain.Model.Commands;
using si730ebu2019126668.API.Observability.Interfaces.REST.Resources;

namespace si730ebu2019126668.API.Observability.Interfaces.REST.Transform;

public static class CreateThingStateCommandFromResourceAssembler
{
    public static CreateThingStateCommand ToCommandFromResource(CreateThingStateResource resource)
    {
        return new CreateThingStateCommand(resource.ThingSerialNumber, resource.CurrentOperationMode,
            resource.CurrentTemperature, resource.CurrentHumidity, resource.CollectedAt);
    }
}