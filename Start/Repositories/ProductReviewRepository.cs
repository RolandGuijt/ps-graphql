using CarvedRock.Api.Data;
using CarvedRock.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Api.Repositories;

public class ProductReviewRepository(CarvedRockDbContext dbContext)
{
    public async Task<IEnumerable<ProductReviewModel>> GetForProduct(int productId)
    {
        var entities = await dbContext.ProductReviews
            .Where(pr => pr.ProductId == productId)
            .ToListAsync();
        return entities.Select(pr => pr.ToModel());
    }

    public async Task<ILookup<int, ProductReviewModel>> GetForProducts(IEnumerable<int> productIds)
    {
        var reviews = await dbContext.ProductReviews
            .Where(pr => productIds.Contains(pr.ProductId)).ToListAsync();
        return reviews
            .Select(r => r.ToModel())
            .ToLookup(r => r.ProductId);
    }

    public async Task<ProductReviewModel> AddReview(ProductReviewModel review)
    {
        var newReviewEntity = new ProductReview();
        review.ToEntity(newReviewEntity);
        dbContext.ProductReviews.Add(newReviewEntity);
        await dbContext.SaveChangesAsync();
        return newReviewEntity.ToModel();
    }
}

