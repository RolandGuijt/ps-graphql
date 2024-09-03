namespace CarvedRock.Api.GraphQL;

[SubscriptionType]
public static class CarvedRockSubscription
{
    [Subscribe]
    [Topic("productId")]
    public static ProductReviewModel ReviewAdded(int productId, [EventMessage] ProductReviewModel review) => review;
}

