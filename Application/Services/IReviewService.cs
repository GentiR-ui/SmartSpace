using Domain.Entities;

namespace Application.Services;

public interface IReviewService
{
    Task<Review?> GetByIdAsync(int id);
    Task<IEnumerable<Review>> GetAllAsync();
    Task<Review> CreateAsync(Review review);
    Task<Review> UpdateAsync(Review review);
    Task DeleteAsync(int id);
}
