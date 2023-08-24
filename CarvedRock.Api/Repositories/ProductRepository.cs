using CarvedRock.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Api.Repositories;

public class ProductRepository
{
    private readonly CarvedRockDbContext _dbContext;

    public ProductRepository(CarvedRockDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ProductModel>> GetAll()
    {
        return await _dbContext.Products
            .Select(p => p.ToModel())
            .ToListAsync();
    }

    public async Task<ProductModel> GetOne(int id)
    {
        var entity = await _dbContext.Products
            .Include(p => p.ProductReviews)
            .SingleOrDefaultAsync(p => p.Id == id);
        return entity.ToModel();
    }
}

