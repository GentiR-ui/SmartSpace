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

    public async Task<Workspace?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Workspace>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Workspace> CreateAsync(Workspace workspace)
    {
        await _repository.AddAsync(workspace);
        return workspace;
    }

    public async Task<Workspace> UpdateAsync(Workspace workspace)
    {
        await _repository.UpdateAsync(workspace);
        return workspace;
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
