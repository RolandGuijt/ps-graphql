using CarvedRock.Api.Repositories;

namespace CarvedRock.Api.GraphQL;

[QueryType]
public static class CarvedRockQuery
{
    public static async Task<IEnumerable<ProductModel>> Products(ProductRepository repo) => await repo.GetAll();
    public static async Task<ProductModel> Product(int id, ProductRepository repo) => await repo.GetOne(id);
    public static async Task<IEnumerable<ProductReviewModel>> Reviews(int productId, ProductReviewRepository repo) =>
        await repo.GetForProduct(productId);
}

