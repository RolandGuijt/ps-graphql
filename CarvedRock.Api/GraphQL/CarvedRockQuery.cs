using System.Collections.Generic;
using System.Threading.Tasks;
using CarvedRock.Api.Repositories;

namespace CarvedRock.Api.GraphQL;

public class CarvedRockQuery
{
    public async Task<IEnumerable<ProductModel>> Products(ProductRepository repo) => await repo.GetAll();
    public async Task<ProductModel> Product(int id, ProductRepository repo) => await repo.GetOne(id);
    public async Task<IEnumerable<ProductReviewModel>> Reviews(int productId, ProductReviewRepository repo) =>
        await repo.GetForProduct(productId);
}

