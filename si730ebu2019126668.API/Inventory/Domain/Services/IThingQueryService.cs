using si730ebu2019126668.API.Inventory.Domain.Model.Aggregates;
using si730ebu2019126668.API.Inventory.Domain.Model.Queries;

namespace si730ebu2019126668.API.Inventory.Domain.Services;

public interface IThingQueryService
{
    Task<Thing?> Handle(GetThingByIdQuery query);
}