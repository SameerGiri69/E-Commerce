using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductInterface _productInterface;

        public ProductController(IProductInterface productInterface)
        {
            _productInterface = productInterface;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _productInterface.GetAllProductsAsync();
            return View(result);
            
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Create(AddProductViewModel productVM)
        {
            var result = await _productInterface.AddProduct(productVM);
            if (result == true)
                return RedirectToAction("Index", "Product");
            return View();  
        }
        
    }
}
