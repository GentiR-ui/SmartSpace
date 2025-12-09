using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly SmartSpaceDbContext _context;

    public AdminRepository(SmartSpaceDbContext context)
    {
        _context = context;
    }

    public async Task<Admin?> GetByIdAsync(int id)
    {
        return await _context.Admins.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Admin>> GetAllAsync()
    {
        return await _context.Admins.ToListAsync();
    }

    public async Task AddAsync(Admin admin)
    {
        _context.Admins.Add(admin);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Admin admin)
    {
        _context.Admins.Update(admin);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var admin = await GetByIdAsync(id);
        if (admin != null)
        {
            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();
        }
    }
}
