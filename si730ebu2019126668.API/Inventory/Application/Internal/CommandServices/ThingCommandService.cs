using si730ebu2019126668.API.Inventory.Domain.Model.Aggregates;
using si730ebu2019126668.API.Inventory.Domain.Model.Commands;
using si730ebu2019126668.API.Inventory.Domain.Repositories;
using si730ebu2019126668.API.Inventory.Domain.Services;
using si730ebu2019126668.API.Shared.Domain.Repositories;

namespace si730ebu2019126668.API.Inventory.Application.Internal.CommandServices;

public class ThingCommandService(IThingRepository thingRepository, IUnitOfWOrk unitOfWOrk) : IThingCommandService
{
    public async Task<Thing?> Handle(CreateThingCommand command)
    {
        var thing = new Thing(command);
        try
        {
            await thingRepository.AddAsync(thing);
            await unitOfWOrk.CompleteAsync();
            return thing;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Thing?> Handle(UpdateOperationModeCommand command)
    {
        var actualThing = await thingRepository.FindBySerialNumberAsync(command.SerialNumber);
        if (actualThing == null) throw new Exception("Thing not found");
        
        try
        {
            actualThing.UpdateOperationMode(command.NewOperationMode);
            await unitOfWOrk.CompleteAsync();
            return actualThing;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}