using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StrawberryShake;

namespace CarvedRock.Web.Controllers
{
    public class HomeController: Controller
    {
        private readonly ICarvedRockClient _Client;

        public HomeController(ICarvedRockClient client)
        {
            _Client = client;
        }


        public async Task<IActionResult> Index()
        {
            var result = await _Client.GetProducts.ExecuteAsync();
            result.EnsureNoErrors();

            return View(result.Data.Products);
        }

        public async Task<IActionResult> ProductDetail(int productId)
        {
            var result = await _Client.GetProduct.ExecuteAsync(productId);
            result.EnsureNoErrors();
            return View(result.Data.Product);
        }

        public IActionResult AddReview(int productId)
        {
            return View(new ProductReviewModelInput {ProductId = productId});
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(ProductReviewModelInput reviewModel)
        {
            var result = await _Client.AddReview.ExecuteAsync(reviewModel);
            result.EnsureNoErrors();
            return RedirectToAction("ProductDetail", new { productId = result.Data.AddProductReview.ProductId });
        }
    }
}
