using CarvedRock.Api.Data;
using CarvedRock.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Api.Repositories;

public class ProductReviewRepository
{
    private readonly CarvedRockDbContext _dbContext;

    public ProductReviewRepository(CarvedRockDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProductReviewModel> GetById(int id, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.ProductReviews
            .SingleAsync(pr => pr.Id == id, cancellationToken);
        return entity.ToModel();
    }

    public async Task<IEnumerable<ProductReviewModel>> GetForProduct(int productId, CancellationToken cancellationToken)
    {
        var entities = await _dbContext.ProductReviews
            .Where(pr => pr.ProductId == productId)
            .ToListAsync(cancellationToken);
        return entities.Select(pr => pr.ToModel());
    }

    public async Task<ILookup<int, ProductReviewModel>> GetForProducts(IEnumerable<int> productIds, CancellationToken cancellationToken)
    {
        var reviews = await _dbContext.ProductReviews
            .Where(pr => productIds.Contains(pr.ProductId)).ToListAsync(cancellationToken);
        return reviews
            .Select(r => r.ToModel())
            .ToLookup(r => r.ProductId);
    }

    public async Task<ProductReviewModel> AddReview(ProductReviewModel review, CancellationToken cancellationToken)
    {
        var newReviewEntity = new ProductReview();
        review.ToEntity(newReviewEntity);
        _dbContext.ProductReviews.Add(newReviewEntity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return newReviewEntity.ToModel();
    }
}

