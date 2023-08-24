using CarvedRock.Api.Repositories;

namespace CarvedRock.Api.GraphQL;

[QueryType]
public static class CarvedRockQuery
{
    [UsePaging(DefaultPageSize = 3)]
    public static async Task<IEnumerable<ProductModel>> Products([Service] ProductRepository repo) => await repo.GetAll();
    public static async Task<ProductModel> Product(int id, [Service] ProductRepository repo) => await repo.GetOne(id);
    public static async Task<IEnumerable<ProductReviewModel>> Reviews(int productId, [Service] ProductReviewRepository repo) =>
        await repo.GetForProduct(productId);
}

