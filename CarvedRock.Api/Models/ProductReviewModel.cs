using CarvedRock.Api.Data.Entities;

public class ProductReviewModel
{
  public int Id { get; set; }
  public int ProductId { get; set; }
  public string Title { get; set; }
  public string Review { get; set; }

  public void ToEntity(ProductReview entity)
  {
    entity.ProductId = ProductId;
    entity.Title = Title;
    entity.Review = Review;
  }
}