using CarvedRock.Api.Data.Entities;
using HotChocolate;
using HotChocolate.Types;

namespace CarvedRock.Api.GraphQL
{
    public class CarvedRockSubscription
    {
        [Subscribe]
        public ProductReview ReviewAdded(int productId, [EventMessage] ProductReview review) => review;
    }
}
