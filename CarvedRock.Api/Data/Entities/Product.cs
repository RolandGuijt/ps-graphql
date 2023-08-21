using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CarvedRock.Api.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(100), Required]
        public string Name { get; set; }
        public ProductTypeEnum Type { get; set; }
        [Required]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Rating { get; set; }
        public DateTimeOffset IntroducedAt { get; set; }

        [StringLength(100)]
        public string PhotoFileName { get; set; }

        public List<ProductReview> ProductReviews { get; set; }

        public ProductModel ToModel()
        {
            return new ProductModel
            {
                Id = Id,
                Name = Name,
                Type = Type,
                Description = Description,
                Price = Price,
                Stock = Stock,
                Rating = Rating,
                IntroducedAt = IntroducedAt,
                PhotoFileName = PhotoFileName,
                ProductReviews = ProductReviews?
                    .Select(r => r.ToModel()).ToList()
            };
        }
    }
}
