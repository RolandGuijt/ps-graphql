using CarvedRock.Api.Repositories;
using HotChocolate.Subscriptions;

namespace CarvedRock.Api.GraphQL;

[MutationType]
public static class CarvedRockMutation
{
    public static async Task<ProductReviewModel> AddProductReview(ProductReviewRepository repo,
        ITopicEventSender sender,
        ProductReviewModel review, CancellationToken cancellationToken)
    {
        var newReview = await repo.AddReview(review, cancellationToken);
        if (newReview.Id != null)
            await sender.SendAsync(nameof(CarvedRockSubscription.OnReviewAdded), new ReviewAddedMessage(newReview.Id.Value), cancellationToken);
        return newReview;
    }
}

