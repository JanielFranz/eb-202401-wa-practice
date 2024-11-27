using si730ebu2019126668.API.Inventory.Domain.Model.Aggregates;
using si730ebu2019126668.API.Shared.Domain.Repositories;

namespace si730ebu2019126668.API.Inventory.Domain.Repositories;

public interface IThingRepository : IBaseRepository<Thing>
{
    Task<bool> ExistsBySerialNumberAsync(String serialNumber);
    Task<Thing?> FindBySerialNumberAsync(String serialNumber);
}