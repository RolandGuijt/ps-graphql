using System;
using System.Collections.Generic;
using System.Linq;
using CarvedRock.Api.Data;
using CarvedRock.Api.Data.Entities;

public class ProductModel
{
  public int Id { get; set; }
  public string Name { get; set; }
  public ProductTypeEnum Type { get; set; }
  public string Description { get; set; }
  public decimal Price { get; set; }
  public int Stock { get; set; }
  public int Rating { get; set; }
  public DateTimeOffset IntroducedAt { get; set; }
  public string PhotoFileName { get; set; }

  public List<ProductReviewModel> ProductReviews { get; set; }
}