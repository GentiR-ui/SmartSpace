using Domain.Entities;

namespace Application.Services;

public interface ILocationService
{
    Task<Location?> GetByIdAsync(Guid id);
    Task<IEnumerable<Location>> GetAllAsync();
    Task<Location> CreateAsync(Location location);
    Task<Location> UpdateAsync(Location location);
    Task DeleteAsync(Guid id);
}
