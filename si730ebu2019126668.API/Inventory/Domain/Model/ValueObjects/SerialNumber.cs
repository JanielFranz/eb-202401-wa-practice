namespace si730ebu2019126668.API.Inventory.Domain.Model.ValueObjects;

public record SerialNumber(String Identifier)
{
    public SerialNumber() : this(Guid.NewGuid().ToString())
    { }

    public string GetSerialNumberAsString()
    {
        return Identifier.ToString();
    }
}