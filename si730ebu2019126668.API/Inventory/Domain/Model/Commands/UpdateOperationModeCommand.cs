namespace si730ebu2019126668.API.Inventory.Domain.Model.Commands;

public record UpdateOperationModeCommand(string SerialNumber, int NewOperationMode);