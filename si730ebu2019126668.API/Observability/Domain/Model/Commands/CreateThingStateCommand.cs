namespace si730ebu2019126668.API.Observability.Domain.Model.Commands;

public record  CreateThingStateCommand(String ThingSerialNumber, int CurrentOperationMode
    , decimal CurrentTemperature, decimal CurrentHumidity, DateTime CollectedAt);