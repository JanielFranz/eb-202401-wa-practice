using si730ebu2019126668.API.Observability.Domain.Model.Commands;
using si730ebu2019126668.API.Observability.Domain.Model.ValueObjects;

namespace si730ebu2019126668.API.Observability.Domain.Model.Aggregates;

public class ThingState
{
    public int Id { get; }
    public ThingSerialNumber ThingSerialNumber { get; private set; }
    public int CurrentOperationMode { get; private set; }
    public decimal CurrentTemperature { get; private set; }
    public decimal CurrentHumidity { get; private set; }
    public DateTime CollectedAt { get; private set; }
    
    public ThingState() {}

    public ThingState(CreateThingStateCommand command)
    {
        ThingSerialNumber = new ThingSerialNumber(command.ThingSerialNumber);

        ValidateOperationModeValue(command.CurrentOperationMode);
        CurrentOperationMode = command.CurrentOperationMode;
        
        CurrentTemperature = command.CurrentTemperature;
        CurrentHumidity = command.CurrentHumidity;

        ValidateCollectedAtDate(command.CollectedAt);
        CollectedAt = command.CollectedAt;
    }

    private void ValidateOperationModeValue(int currentOperationMode)
    {
        if (currentOperationMode < 0 || currentOperationMode > 2)
            throw new ArgumentOutOfRangeException(nameof(currentOperationMode),
                "Operation mode value must be between 0 and 2");
    }

    private void ValidateCollectedAtDate(DateTime collectedAt)
    {
        if (collectedAt > DateTime.UtcNow)
            throw new ArgumentOutOfRangeException(nameof(collectedAt),
                "Collected at date must be in the past");
    }
}