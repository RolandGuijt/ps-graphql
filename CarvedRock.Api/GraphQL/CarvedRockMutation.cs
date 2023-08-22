using CarvedRock.Api.Repositories;
using HotChocolate;
using HotChocolate.Subscriptions;
using System.Threading.Tasks;

namespace CarvedRock.Api.GraphQL;

public class CarvedRockMutation
{
    public async Task<ProductReviewModel> AddProductReview(ProductReviewRepository repo,
        [Service] ITopicEventSender sender,
        ProductReviewModel review)
    {
        var newReview = await repo.AddReview(review);
        await sender.SendAsync("ReviewAdded", newReview);
        return newReview;
    }
}

