using System.Collections.Generic;
using System.Threading.Tasks;
using CarvedRock.Api.Data.Entities;
using CarvedRock.Api.Repositories;
using HotChocolate;

namespace CarvedRock.Api.GraphQL
{
    public class CarvedRockQuery
    {
        public async Task<IEnumerable<ProductModel>> Products([Service]ProductRepository repo) => await repo.GetAll();
        public async Task<ProductModel> Product(int id, [Service]ProductRepository repo) => await repo.GetOne(id);
        public async Task<IEnumerable<ProductReviewModel>> Reviews(int productId, [Service]ProductReviewRepository repo) =>
            await repo.GetForProduct(productId);
    }
}
