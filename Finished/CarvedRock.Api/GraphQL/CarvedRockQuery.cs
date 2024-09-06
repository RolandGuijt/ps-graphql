using CarvedRock.Api.Repositories;

namespace CarvedRock.Api.GraphQL;

[QueryType]
public static class CarvedRockQuery
{
    public static async Task<IEnumerable<ProductModel>> Products(ProductRepository repo, CancellationToken cancellationToken) => await repo.GetAll(cancellationToken);
    public static async Task<ProductModel> Product(int id, ProductRepository repo, CancellationToken cancellationToken) => await repo.GetOne(id, cancellationToken);
    public static async Task<IEnumerable<ProductReviewModel>> Reviews(int productId, ProductReviewRepository repo, CancellationToken cancellationToken) =>
        await repo.GetForProduct(productId, cancellationToken);
}

