using Domain.Entities;
using Domain.Repositories;

namespace Application.Services;

public class WorkspaceService : IWorkspaceService
{
    private readonly IWorkspaceRepository _repository;

    public WorkspaceService(IWorkspaceRepository repository)
    {
        _repository = repository;
    }

    public async Task<WorkSpace?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<WorkSpace>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<WorkSpace> CreateAsync(WorkSpace workspace)
    {
        await _repository.AddAsync(workspace);
        return workspace;
    }

    public async Task<WorkSpace> UpdateAsync(WorkSpace workspace)
    {
        await _repository.UpdateAsync(workspace);
        return workspace;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
