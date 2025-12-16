using Domain.Entities;

namespace Application.Services;

public interface ILocationService
{
    Task<Location?> GetByIdAsync(int id);
    Task<IEnumerable<Location>> GetAllAsync();
    Task<Location> CreateAsync(Location location);
    Task<Location> UpdateAsync(Location location);
    Task DeleteAsync(int id);
}
