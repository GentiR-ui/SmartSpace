using Domain.Entities;
using Domain.Repositories;

namespace Application.Services;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _repository;

    public LocationService(ILocationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Location?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Location>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Location> CreateAsync(Location location)
    {
        await _repository.AddAsync(location);
        return location;
    }

    public async Task<Location> UpdateAsync(Location location)
    {
        await _repository.UpdateAsync(location);
        return location;
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
