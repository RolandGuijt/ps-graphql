using CarvedRock.Api.Data.Entities;
using CarvedRock.Api.Repositories;
using System.Threading.Tasks;

namespace CarvedRock.Api.GraphQL
{
    public class CarvedRockMutation
    {
        public async Task<ProductReview> AddProductReview(ProductReviewRepository reviewRepository, ProductReview review)
        {
            await reviewRepository.AddReview(review);
            return review;
        }
    }
}
