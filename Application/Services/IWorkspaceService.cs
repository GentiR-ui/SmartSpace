using Domain.Entities;

namespace Application.Services;

public interface IWorkspaceService
{
    Task<Workspace?> GetByIdAsync(int id);
    Task<IEnumerable<Workspace>> GetAllAsync();
    Task<Workspace> CreateAsync(Workspace workspace);
    Task<Workspace> UpdateAsync(Workspace workspace);
    Task DeleteAsync(int id);
}
