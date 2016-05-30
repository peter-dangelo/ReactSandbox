using System.Collections.Generic;
using System.Web.Mvc;
using ReactSandbox.Models;

namespace ReactSandbox.Controllers
{
    [Route("products")]
    public class ProductsController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            var model = new ProductsModel
            {
                Products = new List<ProductModel>
                {
                    new ProductModel {Category = "Sporting Goods", Price = "$49.99", Stocked = true, Name = "Football"},
                    new ProductModel {Category = "Sporting Goods", Price = "$9.99", Stocked = true, Name = "Baseball"},
                    new ProductModel {Category = "Sporting Goods", Price = "$29.99", Stocked = false, Name = "Basketball"},
                    new ProductModel {Category = "Electronics", Price = "$99.99", Stocked = true, Name = "iPod Touch"},
                    new ProductModel {Category = "Electronics", Price = "$399.99", Stocked = false, Name = "iPhone 5"},
                    new ProductModel {Category = "Electronics", Price = "$199.99", Stocked = true, Name = "Nexus 7"}
                }
            };

            return View(model);
        }
    }
}