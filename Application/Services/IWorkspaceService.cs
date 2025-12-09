using Domain.Entities;

namespace Application.Services;

public interface IWorkspaceService
{
    Task<WorkSpace?> GetByIdAsync(Guid id);
    Task<IEnumerable<WorkSpace>> GetAllAsync();
    Task<WorkSpace> CreateAsync(WorkSpace workspace);
    Task<WorkSpace> UpdateAsync(WorkSpace workspace);
    Task DeleteAsync(Guid id);
}
