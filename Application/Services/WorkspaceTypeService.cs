using Domain.Entities;
using Domain.Repositories;

namespace Application.Services;

public class WorkspaceTypeService : IWorkspaceTypeService
{
    private readonly IWorkspaceTypeRepository _repository;

    public WorkspaceTypeService(IWorkspaceTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<WorkspaceType?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<WorkspaceType>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<WorkspaceType> CreateAsync(WorkspaceType workspaceType)
    {
        await _repository.AddAsync(workspaceType);
        return workspaceType;
    }

    public async Task<WorkspaceType> UpdateAsync(WorkspaceType workspaceType)
    {
        await _repository.UpdateAsync(workspaceType);
        return workspaceType;
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
