using System.ComponentModel.DataAnnotations;
namespace CarvedRock.Api.Data.Entities
{
    public class ProductReview
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [StringLength(200), Required]
        public string Title { get; set; }
        public string Review { get; set; }

        public ProductReviewModel ToModel()
        {
            return new ProductReviewModel
            {
                Id = Id,
                ProductId = ProductId,
                Title = Title,
                Review = Review
            };
        }
    }
}
