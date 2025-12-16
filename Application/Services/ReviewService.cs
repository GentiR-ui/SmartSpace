using Domain.Entities;
using Domain.Repositories;

namespace Application.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _repository;

    public ReviewService(IReviewRepository repository)
    {
        _repository = repository;
    }

    public async Task<Review?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Review>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Review> CreateAsync(Review review)
    {
        await _repository.AddAsync(review);
        return review;
    }

    public async Task<Review> UpdateAsync(Review review)
    {
        await _repository.UpdateAsync(review);
        return review;
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
