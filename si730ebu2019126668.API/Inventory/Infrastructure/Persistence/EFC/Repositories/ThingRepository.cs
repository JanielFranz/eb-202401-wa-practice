using Microsoft.EntityFrameworkCore;
using si730ebu2019126668.API.Inventory.Domain.Model.Aggregates;
using si730ebu2019126668.API.Inventory.Domain.Repositories;
using si730ebu2019126668.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebu2019126668.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730ebu2019126668.API.Inventory.Infrastructure.Persistence.EFC.Repositories;

public class ThingRepository(AppDbContext context) : BaseRepository<Thing>(context), IThingRepository
{
    public async Task<bool> ExistsBySerialNumberAsync(string serialNumber)
    {
        return await Context.Set<Thing>().AnyAsync(thing => thing.SerialNumber.Identifier == serialNumber);
    }

    public async Task<Thing?> FindBySerialNumberAsync(string serialNumber)
    {
        return await Context.Set<Thing>().FirstOrDefaultAsync(thing => thing.SerialNumber.Identifier == serialNumber);
    }
}