using CarvedRock.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Api.Repositories;

public class ProductRepository(CarvedRockDbContext dbContext)
{
    public async Task<IEnumerable<ProductModel>> GetAll()
    {
        return await dbContext.Products
            .Include(p => p.ProductReviews)
            .Select(p => p.ToModel())
            .ToListAsync();
    }

    public async Task<ProductModel> GetOne(int id)
    {
        var entity = await dbContext.Products
            .Include(p => p.ProductReviews)
            .SingleOrDefaultAsync(p => p.Id == id);
        return entity.ToModel();
    }
}

