namespace si730ebu2019126668.API.Inventory.Domain.Model.Commands;

public record CreateThingCommand(string Model, decimal MaximumTemperatureThreshold, 
    decimal MinimumHumidityThreshold);