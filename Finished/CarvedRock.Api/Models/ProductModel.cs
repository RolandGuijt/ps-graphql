using CarvedRock.Api.Data;

public record ProductModel(int Id, string Name, ProductTypeEnum Type, string Description, 
  decimal Price, int Stock, int Rating, DateTimeOffset IntroducedAt, string PhotoFileName)
{
  public List<ProductReviewModel> ProductReviews { get; init; }
}