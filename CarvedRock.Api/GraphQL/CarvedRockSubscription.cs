using HotChocolate;
using HotChocolate.Types;

namespace CarvedRock.Api.GraphQL;

public class CarvedRockSubscription
{
    [Subscribe]
    public ProductReviewModel ReviewAdded(int productId, [EventMessage] ProductReviewModel review) => review;
}

