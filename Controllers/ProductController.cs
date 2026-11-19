using Microsoft.AspNetCore.Mvc;
using MVC_S_01.Models;

namespace MVC_S_01.Controllers
{
    public class ProductController : Controller
    {
        #region Actions

        // BaseURL/Product/Index
        public IActionResult Index()
        {
            return View();
        }

        // BaseURL/Product/GetProducts
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = new List<Product>()
            {
                new() { Id = 1, Name = "IPhone 16 Pro Max" },
                new() { Id = 2, Name = "IPhone 17 Pro Max"}
            };

            return Json(products);
        }

        // BaseUrl/Product/GetProductById/{id}
        [HttpGet]
        public IActionResult GetProductById(int id)
        {
            if (id < 0)
                return BadRequest();
            //else if (id == 0)
            //    return RedirectToAction(nameof(GetProducts));
            else if (id > 50)
                return Redirect("https://www.google.com");
            else
                return Json(new Product() { Id = id });
        }
        #endregion

        #region Routig

        [HttpGet("Json")]
        // BaseUrl/Product/JsonAction -- Convential Routing
        // BaseUrl/Prod/JsonAction -- Attribute Routing
        // BaseUrl/Prod/Json -- Attribute Routing

        public IActionResult JsonAction()
        {
            return Json("Hello From Json Action");
        }

        #endregion

        #region Model Binding

        // BaseUrl/Product/Search?Name=IPhone17&Color=Black
        // BaseUrl/Product/Search?Name=IPhone17&Storeage=512

        public IActionResult Search(ProductFilter filter)
        {
            return View();
        }

        // Route
        // BaseUrl/Product/GetById/10

        // BaseUrl/Product/GetById/10           -> id = 0 , otherId = 0
        // BaseUrl/Product/GetById?id=20        -> id = 20 , otherId = 0
        // BaseUrl/Product/GetById?otherId=20   -> id = 0 , otherId = 0
        // BaseUrl/Product/GetById?Id2=20&id=50 -> id = 50 , otherId = 20

        public IActionResult GetById([FromRoute] int id, [FromRoute(Name = "id2")] int otherId)
        {
            return Json("");
        }

        #endregion
    }
}

// BaseUrl/Product/IPhone17ProMax/Orange/512GB
// BaseUrl/Product?Name=IPhone17ProMax&Color=Orange&Storeage=512GB