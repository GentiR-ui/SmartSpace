using Domain.Entities;

namespace Application.Services;

public interface IWorkspaceTypeService
{
    Task<WorkspaceType?> GetByIdAsync(int id);
    Task<IEnumerable<WorkspaceType>> GetAllAsync();
    Task<WorkspaceType> CreateAsync(WorkspaceType workspaceType);
    Task<WorkspaceType> UpdateAsync(WorkspaceType workspaceType);
    Task DeleteAsync(int id);
}
