using CarvedRock.Api.Data.Entities;

public record ProductReviewModel(int Id, int ProductId, string Title, string Review)
{
  public void ToEntity(ProductReview entity)
  {
    entity.ProductId = ProductId;
    entity.Title = Title;
    entity.Review = Review;
  }
}