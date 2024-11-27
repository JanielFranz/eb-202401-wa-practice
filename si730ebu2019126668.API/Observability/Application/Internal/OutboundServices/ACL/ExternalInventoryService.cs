using si730ebu2019126668.API.Inventory.Interfaces.ACL;

namespace si730ebu2019126668.API.Observability.Application.Internal.OutboundServices.ACL;

public class ExternalInventoryService(IInventoryContextFacade inventoryContextFacade)
{
    public async Task<bool> ExistsSerialNumber(string serialNumber)
    {
        return await inventoryContextFacade.ExistsBySerialNumber(serialNumber);
    }

    public async Task<bool> IsOperationModeUpdated(string serialNumber, int currentOperationMode)
    {
        return await inventoryContextFacade.IsOperationModeUpdated(serialNumber, currentOperationMode);
    }
}