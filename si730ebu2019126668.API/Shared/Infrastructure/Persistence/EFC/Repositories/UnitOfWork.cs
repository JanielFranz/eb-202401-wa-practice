using si730ebu2019126668.API.Shared.Domain.Repositories;
using si730ebu2019126668.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace si730ebu2019126668.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWOrk
{
    private readonly AppDbContext _context;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}