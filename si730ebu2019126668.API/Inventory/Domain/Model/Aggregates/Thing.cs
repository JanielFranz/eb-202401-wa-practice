using System.ComponentModel.DataAnnotations.Schema;
using si730ebu2019126668.API.Inventory.Domain.Model.Commands;
using si730ebu2019126668.API.Inventory.Domain.Model.ValueObjects;

namespace si730ebu2019126668.API.Inventory.Domain.Model.Aggregates;

public class Thing
{
    public int Id { get; }
    public SerialNumber SerialNumber { get; private set; }
    public string Model { get; private set; }
    public EOperationMode OperationMode { get; private set; }
    public decimal MaximumTemperatureThreshold { get; private set; }
    public decimal MinimumHumidityThreshold { get; private set; }
    
    

    public Thing(){ }

public Thing(CreateThingCommand command)
    {
        Model = command.Model;
        
        ValidateTemperatureAndHumidityThresholds(command.MaximumTemperatureThreshold, command.MinimumHumidityThreshold);
        MaximumTemperatureThreshold = command.MaximumTemperatureThreshold;
        MinimumHumidityThreshold = command.MinimumHumidityThreshold;
        
        OperationMode = EOperationMode.ScheduleDriven;
        SerialNumber = new SerialNumber();
    }
    
    private void ValidateTemperatureAndHumidityThresholds(decimal maximumTemperatureThreshold, 
        decimal minimumHumidityThreshold)
    {
        if (maximumTemperatureThreshold < -40 || maximumTemperatureThreshold > 85)
        {
            throw new ArgumentOutOfRangeException(nameof(maximumTemperatureThreshold), "Maximum temperature threshold must be between -40 and 85.");
        }
        
        if (minimumHumidityThreshold < 0 || minimumHumidityThreshold > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(minimumHumidityThreshold), "Minimum humidity threshold must be greater than or equal to 0.");
        }
    }

    public void UpdateOperationMode(int currentOperationMode)
    {
        switch (currentOperationMode)
        {
            case 0: OperationMode = EOperationMode.ScheduleDriven; break;
            case 1: OperationMode = EOperationMode.TemperatureDriven; break;
            case 2: OperationMode = EOperationMode.HumidityDriven; break;
            default: throw new ArgumentOutOfRangeException(nameof(currentOperationMode), "Operation mode value must be between 0 and 2.");
        }
    }
    
}