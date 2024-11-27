using si730ebu2019126668.API.Inventory.Domain.Model.Aggregates;
using si730ebu2019126668.API.Inventory.Domain.Model.Queries;
using si730ebu2019126668.API.Inventory.Domain.Repositories;
using si730ebu2019126668.API.Inventory.Domain.Services;
using si730ebu2019126668.API.Shared.Domain.Repositories;

namespace si730ebu2019126668.API.Inventory.Application.Internal.QueryServices;

public class ThingQueryService(IThingRepository thingRepository) : IThingQueryService
{
    public async Task<Thing?> Handle(GetThingByIdQuery query)
    {
        return await thingRepository.FindByIdAsync(query.Id);
    }
}