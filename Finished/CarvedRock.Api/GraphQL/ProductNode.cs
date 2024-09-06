using CarvedRock.Api.Repositories;
namespace CarvedRock.Api.GraphQL;

[ExtendObjectType<ProductModel>]
public static class ProductNode
{
    public static decimal GetTotalStockValue([Parent] ProductModel model)
    {
        return model.Stock * model.Price;
    }

    public static async Task<ProductReviewModel[]> GetReviewsById(
        [Parent] ProductModel product,
        IReviewsByProductIdDataLoader dataloader) =>
        await dataloader.LoadAsync(product.Id);

    [DataLoader(ServiceScope = DataLoaderServiceScope.DataLoaderScope)]
    public static async Task<ILookup<int, ProductReviewModel>> GetReviewsByProductId(
        IReadOnlyList<int> ids,
        [Service] ProductReviewRepository repo, CancellationToken cancellationToken) => await repo.GetForProducts(ids, cancellationToken);
}

