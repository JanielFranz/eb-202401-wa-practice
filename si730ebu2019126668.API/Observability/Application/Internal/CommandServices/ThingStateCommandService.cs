using si730ebu2019126668.API.Observability.Application.Internal.OutboundServices.ACL;
using si730ebu2019126668.API.Observability.Domain.Model.Aggregates;
using si730ebu2019126668.API.Observability.Domain.Model.Commands;
using si730ebu2019126668.API.Observability.Domain.Repositories;
using si730ebu2019126668.API.Observability.Domain.Services;
using si730ebu2019126668.API.Shared.Domain.Repositories;

namespace si730ebu2019126668.API.Observability.Application.Internal.CommandServices;

public class ThingStateCommandService(IThingStateRepository thingStateRepository
    , IUnitOfWOrk unitOfWork, ExternalInventoryService externalInventoryService) : IThingStateCommandService
{
    public async Task<ThingState?> Handle(CreateThingStateCommand command)
    {
        if(!await externalInventoryService.ExistsSerialNumber(command.ThingSerialNumber))
            throw new InvalidOperationException("Thing with this serial number doesn't exist");

        if(await thingStateRepository
           .ExistsByThingSerialNumberAndCollectedAtAsync(command.ThingSerialNumber, command.CollectedAt))
            throw new InvalidOperationException("Thing state with this serial number and collected at already exists");
        
        var thingState = new ThingState(command);
        

        try
        {
            if (await externalInventoryService.IsOperationModeUpdated(command.ThingSerialNumber,
                    command.CurrentOperationMode))
            {
                await thingStateRepository.AddAsync(thingState);
                await unitOfWork.CompleteAsync();
                return thingState;
            }
            else
            {
                throw new InvalidOperationException("Operation mode is not updated");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}