using Domain.Entities;
using Domain.Repositories;

namespace Application.Services;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _repository;

    public AdminService(IAdminRepository repository)
    {
        _repository = repository;
    }

    public async Task<Admin?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Admin>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Admin> CreateAsync(Admin admin)
    {
        await _repository.AddAsync(admin);
        return admin;
    }

    public async Task<Admin> UpdateAsync(Admin admin)
    {
        await _repository.UpdateAsync(admin);
        return admin;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
