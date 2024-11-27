using si730ebu2019126668.API.Inventory.Domain.Model.Commands;
using si730ebu2019126668.API.Inventory.Domain.Repositories;
using si730ebu2019126668.API.Inventory.Domain.Services;
using si730ebu2019126668.API.Inventory.Interfaces.ACL;

namespace si730ebu2019126668.API.Inventory.Application.ACL;

public class InventoryContextFacade(IThingRepository thingRepository, IThingCommandService thingCommandService) : IInventoryContextFacade
{
    public async Task<bool> ExistsBySerialNumber(string serialNumber)
    {
        return await thingRepository.ExistsBySerialNumberAsync(serialNumber);
    }

    public async Task<bool> IsOperationModeUpdated(string serialNumber, int operationMode)
    {
        var updateOperationModeCommand = new UpdateOperationModeCommand(serialNumber, operationMode);
        var thingUpdated = await thingCommandService.Handle(updateOperationModeCommand);
        
        return (thingUpdated is not null);
    }
}