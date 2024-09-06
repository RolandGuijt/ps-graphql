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

    public async Task<IEnumerable<ProductModel>> GetAll(CancellationToken cancellationToken)
    {
        return await _dbContext.Products
            .Include(p => p.ProductReviews)
            .Select(p => p.ToModel())
            .ToListAsync(cancellationToken);
    }

    public async Task<ProductModel> GetOne(int id, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Products
            .Include(p => p.ProductReviews)
            .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
        return entity.ToModel();
    }
}

