using System.Collections.Generic;
using System.Threading.Tasks;
using CarvedRock.Api.Data.Entities;
using CarvedRock.Api.Repositories;
using HotChocolate;

namespace CarvedRock.Api.GraphQL
{
    public class CarvedRockQuery
    {
        public async Task<IEnumerable<Product>> Products([Service]ProductRepository repo) => await repo.GetAll();
        public async Task<Product> Product(int id, [Service]ProductRepository repo) => await repo.GetOne(id);
        public async Task<IEnumerable<ProductReview>> Reviews(int productId, [Service]ProductReviewRepository repo) =>
            await repo.GetForProduct(productId);
    }
}
