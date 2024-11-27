namespace si730ebu2019126668.API.Inventory.Interfaces.REST.Resources;

public record ThingResource(int Id, string SerialNumber, string Model, string OperationMode
    , decimal MaximumTemperatureThreshold, decimal MinimumHumidityThreshold);