using Microsoft.AspNetCore.Mvc;
using Shop.Application.ProductsAdmin;
using Shop.Application.StockAdmin;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace ShopUI.Controllers
{
    [Route("[controller]")]
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

        [HttpGet("Products/{id}")]
        public IActionResult GetProduct(int Id) =>
           Ok(new GetProduct(_ctx).Do(Id));

        [HttpPost("updateProducts")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProduct.Request request) =>
           Ok(await new UpdateProduct(_ctx).Do(request));


        [HttpPost("Product")]
        public async Task<IActionResult> CreateProduct([FromBody] CreatProduct.Request request) =>
           Ok(await new CreatProduct(_ctx).Do(request));

        [HttpDelete("Product/{id}")]
        public async Task<IActionResult> DeleteProduct(int Id) =>
           Ok(await new DeleteProduct(_ctx).Do(Id));




        [HttpGet("stocks")]
        public IActionResult GetStock() =>
    Ok(new GetStock(_ctx).Do());



        [HttpPut("stock")]
        public async Task<IActionResult> UpdateStock([FromBody] UpdateStock.Request request) =>
           Ok(await new UpdateStock(_ctx).Do(request));


        [HttpPost("stock")]
        public async Task<IActionResult> CreateStock([FromBody] CreateStock.Request request) =>
           Ok(await new CreateStock(_ctx).Do(request));

        [HttpDelete("stock/{id}")]
        public async Task<IActionResult> DeleteStock(int Id) =>
           Ok(await new DeleteStock(_ctx).Do(Id));
    }
}
