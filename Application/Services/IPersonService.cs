using Domain.Entities;

namespace Application.Services;

public interface IPersonService
{
    Task<Person?> GetByIdAsync(int id);
    Task<IEnumerable<Person>> GetAllAsync();
    Task<Person> CreateAsync(Person person);
    Task<Person> UpdateAsync(Person person);
    Task DeleteAsync(int id);
}
