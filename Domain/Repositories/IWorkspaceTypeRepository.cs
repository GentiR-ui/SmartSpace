using Domain.Entities;

namespace Domain.Repositories;

public interface IWorkspaceTypeRepository
{
    Task<WorkspaceType?> GetByIdAsync(int id);
    Task<IEnumerable<WorkspaceType>> GetAllAsync();
    Task AddAsync(WorkspaceType workspaceType);
    Task UpdateAsync(WorkspaceType workspaceType);
    Task DeleteAsync(int id);
}
