namespace si730ebu2019126668.API.Inventory.Interfaces.REST.Resources;

public record CreateThingResource(string Model, decimal MaximumTemperatureThreshold, 
    decimal MinimumHumidityThreshold);