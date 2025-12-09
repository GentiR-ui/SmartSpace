using Domain.Entities;

namespace Application.Services;

public interface IPersonService
{
    Task<Person?> GetByIdAsync(Guid id);
    Task<IEnumerable<Person>> GetAllAsync();
    Task<Person> CreateAsync(Person person);
    Task<Person> UpdateAsync(Person person);
    Task DeleteAsync(Guid id);
}
