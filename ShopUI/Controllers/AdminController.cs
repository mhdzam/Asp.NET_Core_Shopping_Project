using Microsoft.AspNetCore.Mvc;
using Shop.Application.ProductsAdmin;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace ShopUI.Controllers
{
    [Route("[Controller]")]
    public class AdminController : Controller
    {
        private ApplicationDbContext _ctx;

        public AdminController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        [HttpGet("Products")]
        public IActionResult GetProducts() =>
            Ok( new GetProducts(_ctx).Do());

        [HttpGet("Products/(Id")]
        public IActionResult GetProduct(int Id) =>
           Ok(new GetProduct(_ctx).Do(Id));

        [HttpPost("Products")]
        public IActionResult UpdateProduct(UpdateProduct.ProductViewModel product) =>
           Ok(new UpdateProduct(_ctx).Do(product));


        [HttpPut("Products")]
        public IActionResult CreateProducts(CreatProduct.ProductViewModel product) =>
           Ok(new CreatProduct(_ctx).Do(product));

        [HttpDelete("Products/(Id)")]
        public IActionResult DeleteProduct(int Id) =>
           Ok(new DeleteProduct(_ctx).Do(Id));
    }
}
