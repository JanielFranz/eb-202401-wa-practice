using si730ebu2019126668.API.Inventory.Domain.Model.Aggregates;
using si730ebu2019126668.API.Inventory.Domain.Model.Commands;

namespace si730ebu2019126668.API.Inventory.Domain.Services;

public interface IThingCommandService
{
    Task<Thing?> Handle(CreateThingCommand command);
    Task<Thing?> Handle(UpdateOperationModeCommand command);
}