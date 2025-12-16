using Domain.Entities;

namespace Domain.Repositories;

public interface IReviewRepository
{
    Task<Review?> GetByIdAsync(int id);
    Task<IEnumerable<Review>> GetAllAsync();
    Task AddAsync(Review review);
    Task UpdateAsync(Review review);
    Task DeleteAsync(int id);
}
