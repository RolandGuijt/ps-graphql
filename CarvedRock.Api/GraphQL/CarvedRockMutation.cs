using CarvedRock.Api.Data.Entities;
using CarvedRock.Api.Repositories;
using HotChocolate;
using HotChocolate.Subscriptions;
using System.Threading.Tasks;

namespace CarvedRock.Api.GraphQL
{
    public class CarvedRockMutation
    {
        public async Task<ProductReview> AddProductReview([Service] ProductReviewRepository repo,
            [Service] ITopicEventSender sender,
            ProductReview review)
        {
            var newReview = await repo.AddReview(review);
            await sender.SendAsync("ReviewAdded", newReview);
            return newReview;
        }
    }
}
