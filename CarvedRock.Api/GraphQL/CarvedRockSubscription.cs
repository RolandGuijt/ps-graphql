namespace CarvedRock.Api.GraphQL;

[SubscriptionType]
public static class CarvedRockSubscription
{
    [Subscribe]
    public static ProductReviewModel ReviewAdded(int productId, [EventMessage] ProductReviewModel review) => review;
}

