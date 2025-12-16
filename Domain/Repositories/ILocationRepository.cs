using Domain.Entities;

namespace Domain.Repositories;

public interface ILocationRepository
{
    Task<Location?> GetByIdAsync(int id);
    Task<IEnumerable<Location>> GetAllAsync();
    Task AddAsync(Location location);
    Task UpdateAsync(Location location);
    Task DeleteAsync(int id);
}
