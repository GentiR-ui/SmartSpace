using Domain.Entities;

namespace Domain.Repositories;

public interface IWorkspaceRepository
{
	Task<Workspace?> GetByIdAsync(int id);
	Task<IEnumerable<Workspace>> GetAllAsync();
	Task AddAsync(Workspace workspace);
	Task UpdateAsync(Workspace workspace);
	Task DeleteAsync(int id);
}
