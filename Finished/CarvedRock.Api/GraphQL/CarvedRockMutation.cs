using CarvedRock.Api.Repositories;
using HotChocolate.Subscriptions;

namespace CarvedRock.Api.GraphQL;

[MutationType]
public static class CarvedRockMutation
{
    public static async Task<ProductReviewModel> AddProductReview(ProductReviewRepository repo,
        ITopicEventSender sender,
        ProductReviewModel review)
    {
        var newReview = await repo.AddReview(review);
        await sender.SendAsync("ReviewAdded", newReview);
        return newReview;
    }
}

