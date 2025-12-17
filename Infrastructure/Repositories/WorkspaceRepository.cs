using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class WorkspaceRepository : IWorkspaceRepository
{
    private readonly SmartSpaceDbContext _context;

    public WorkspaceRepository(SmartSpaceDbContext context)
    {
        _context = context;
    }

    public async Task<Workspace?> GetByIdAsync(int id)
    {
        return await _context.Workspaces
            .FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task<IEnumerable<Workspace>> GetAllAsync()
    {
        return await _context.Workspaces.ToListAsync();
    }

    public async Task AddAsync(Workspace workspace)
    {
        _context.Workspaces.Add(workspace);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Workspace workspace)
    {
        _context.Workspaces.Update(workspace);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var workspace = await GetByIdAsync(id);
        if (workspace != null)
        {
            _context.Workspaces.Remove(workspace);
            await _context.SaveChangesAsync();
        }
    }
}
