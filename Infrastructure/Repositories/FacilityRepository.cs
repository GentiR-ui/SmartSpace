using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class FacilityRepository : IFacilityRepository
{
    private readonly SmartSpaceDbContext _context;

    public FacilityRepository(SmartSpaceDbContext context)
    {
        _context = context;
    }

    public async Task<Facility?> GetByIdAsync(int id)
    {
        return await _context.Facilities.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<IEnumerable<Facility>> GetAllAsync()
    {
        return await _context.Facilities.ToListAsync();
    }

    public async Task AddAsync(Facility facility)
    {
        _context.Facilities.Add(facility);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Facility facility)
    {
        _context.Facilities.Update(facility);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var facility = await GetByIdAsync(id);
        if (facility != null)
        {
            _context.Facilities.Remove(facility);
            await _context.SaveChangesAsync();
        }
    }
}
