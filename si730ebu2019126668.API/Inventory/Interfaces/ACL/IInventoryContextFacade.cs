namespace si730ebu2019126668.API.Inventory.Interfaces.ACL;

public interface IInventoryContextFacade
{
    Task<bool> ExistsBySerialNumber(String serialNumber);
    Task<bool> IsOperationModeUpdated(String serialNumber, int operationMode);
}