using Microsoft.AspNetCore.Mvc;
using GeneralStoreMVC.Data;
using ViewModels.ProductVM;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    
    public class Productcontroller : Controller
    {
        private readonly GeneralStoreDb23Context _ctx;
        public Productcontroller(GeneralStoreDb23Context ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _ctx.Products.Select(p=>new ProductIndexModel{
                Id =p.Id,
                Name = p.Name,
                QuantityInStock=p.QuantityInStock,
                Price = p.Price    
            }).ToListAsync();

            return View(products);
        }
    }
}