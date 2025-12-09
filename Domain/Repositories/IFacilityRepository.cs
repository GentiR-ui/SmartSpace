using Domain.Entities;

namespace Domain.Repositories;

public interface IFacilityRepository
{
    Task<Facility?> GetByIdAsync(int id);
    Task<IEnumerable<Facility>> GetAllAsync();
    Task AddAsync(Facility facility);
    Task UpdateAsync(Facility facility);
    Task DeleteAsync(int id);
}
