namespace si730ebu2019126668.API.Observability.Interfaces.REST.Resources;

public record  ThingStateResource(int Id, String ThingSerialNumber, int CurrentOperationMode
    , decimal CurrentTemperature, decimal CurrentHumidity, DateTime CollectedAt);