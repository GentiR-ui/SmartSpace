using Domain.Entities;
using Domain.Repositories;

namespace Application.Services;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _repository;

    public ReservationService(IReservationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Reservation?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Reservation>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Reservation> CreateAsync(Reservation reservation)
    {
        await _repository.AddAsync(reservation);
        return reservation;
    }

    public async Task<Reservation> UpdateAsync(Reservation reservation)
    {
        await _repository.UpdateAsync(reservation);
        return reservation;
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
