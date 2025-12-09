using Domain.Entities;
using Domain.Repositories;

namespace Application.Services;

public class FacilityService : IFacilityService
{
    private readonly IFacilityRepository _repository;

    public FacilityService(IFacilityRepository repository)
    {
        _repository = repository;
    }

    public async Task<Facility?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Facility>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Facility> CreateAsync(Facility facility)
    {
        await _repository.AddAsync(facility);
        return facility;
    }

    public async Task<Facility> UpdateAsync(Facility facility)
    {
        await _repository.UpdateAsync(facility);
        return facility;
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
