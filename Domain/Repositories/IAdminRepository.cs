using Domain.Entities;

namespace Domain.Repositories;

public interface IAdminRepository
{
    Task<Admin?> GetByIdAsync(int id);
    Task<IEnumerable<Admin>> GetAllAsync();
    Task AddAsync(Admin admin);
    Task UpdateAsync(Admin admin);
    Task DeleteAsync(int id);
}
