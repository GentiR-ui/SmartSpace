using Domain.Entities;
using Domain.Repositories;

namespace Application.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _repository;

    public PaymentService(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Payment?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Payment>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Payment> CreateAsync(Payment payment)
    {
        await _repository.AddAsync(payment);
        return payment;
    }

    public async Task<Payment> UpdateAsync(Payment payment)
    {
        await _repository.UpdateAsync(payment);
        return payment;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
