using Domain.Entities;

namespace Application.Services;

public interface IAdminService
{
    Task<Admin?> GetByIdAsync(Guid id);
    Task<IEnumerable<Admin>> GetAllAsync();
    Task<Admin> CreateAsync(Admin admin);
    Task<Admin> UpdateAsync(Admin admin);
    Task DeleteAsync(Guid id);
}
