using CarvedRock.Api.Repositories;

namespace CarvedRock.Api.GraphQL;

[SubscriptionType]
public static class CarvedRockSubscription
{
    [Subscribe]
    [Topic]
    public static async Task<ProductReviewModel> OnReviewAdded(ProductReviewRepository repo, [EventMessage] ReviewAddedMessage reviewAddedMessage, CancellationToken cancellationToken)
        => await repo.GetById(reviewAddedMessage.ReviewId, cancellationToken);
}


