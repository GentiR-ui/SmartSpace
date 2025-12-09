using Domain.Entities;
using Domain.Repositories;

namespace Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Customer> CreateAsync(Customer customer)
    {
        await _repository.AddAsync(customer);
        return customer;
    }

    public async Task<Customer> UpdateAsync(Customer customer)
    {
        await _repository.UpdateAsync(customer);
        return customer;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
