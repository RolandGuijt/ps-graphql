using System.Threading.Tasks;
using CarvedRock.Web.Models;
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
            //var responseModel = await _httpClient.GetProducts();
            //responseModel.ThrowErrors();
            return View(result.Data.Products);
        }

        public async Task<IActionResult> ProductDetail(int productId)
        {
            //_productGraphClient.SubscribeToUpdates();
            var result = await _Client.GetProduct.ExecuteAsync(productId);
            result.EnsureNoErrors();
            return View(result.Data.Product);
        }

        public IActionResult AddReview(int productId)
        {
            return View(new ProductReviewModel {ProductId = productId});
        }

        //[HttpPost]
        //public async Task<IActionResult> AddReview(ProductReviewModel reviewModel)
        //{
        //    await _productGraphClient.AddReview(reviewModel);
        //    return RedirectToAction("ProductDetail", new {productId = reviewModel.ProductId});
        //}
    }
}
