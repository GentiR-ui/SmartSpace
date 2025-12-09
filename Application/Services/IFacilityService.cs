using Domain.Entities;

namespace Application.Services;

public interface IFacilityService
{
    Task<Facility?> GetByIdAsync(Guid id);
    Task<IEnumerable<Facility>> GetAllAsync();
    Task<Facility> CreateAsync(Facility facility);
    Task<Facility> UpdateAsync(Facility facility);
    Task DeleteAsync(Guid id);
}
