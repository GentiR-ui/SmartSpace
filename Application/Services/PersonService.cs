using Domain.Entities;
using Domain.Repositories;

namespace Application.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _repository;

    public PersonService(IPersonRepository repository)
    {
        _repository = repository;
    }

    public async Task<Person?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Person>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Person> CreateAsync(Person person)
    {
        await _repository.AddAsync(person);
        return person;
    }

    public async Task<Person> UpdateAsync(Person person)
    {
        await _repository.UpdateAsync(person);
        return person;
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
