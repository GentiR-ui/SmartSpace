using Domain.Entities;

namespace Domain.Repositories;

public interface IWorkspaceTypeRepository
{
    Task<WorkspaceType?> GetByIdAsync(Guid id);
    Task<IEnumerable<WorkspaceType>> GetAllAsync();
    Task AddAsync(WorkspaceType workspaceType);
    Task UpdateAsync(WorkspaceType workspaceType);
    Task DeleteAsync(Guid id);
}
