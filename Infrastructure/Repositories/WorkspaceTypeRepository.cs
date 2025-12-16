using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class WorkspaceTypeRepository : IWorkspaceTypeRepository
{
    private readonly SmartSpaceDbContext _context;

    public WorkspaceTypeRepository(SmartSpaceDbContext context)
    {
        _context = context;
    }

    public async Task<WorkspaceType?> GetByIdAsync(int id)
    {
        return await _context.WorkspaceTypes.FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task<IEnumerable<WorkspaceType>> GetAllAsync()
    {
        return await _context.WorkspaceTypes.ToListAsync();
    }

    public async Task AddAsync(WorkspaceType workspaceType)
    {
        _context.WorkspaceTypes.Add(workspaceType);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(WorkspaceType workspaceType)
    {
        _context.WorkspaceTypes.Update(workspaceType);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var workspaceType = await GetByIdAsync(id);
        if (workspaceType != null)
        {
            _context.WorkspaceTypes.Remove(workspaceType);
            await _context.SaveChangesAsync();
        }
    }
}
