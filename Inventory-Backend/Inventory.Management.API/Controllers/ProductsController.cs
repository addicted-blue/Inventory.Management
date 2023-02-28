using Inventory.Management.API.Modals;
using Inventory.Management.API.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using RouteMVC = Microsoft.AspNetCore.Mvc;

namespace Inventory.Management.API.Controllers
{
    [ApiVersion("1.0")]
    [RouteMVC.Produces("application/json")]
    [RouteMVC.Route(Route.ApiPrefix)]
    public class ProductsController : ApiBaseController
    {
        private IProductService _productService;

        public ProductsController(ILoggerFactory logerFactory, IProductService productService) : base(logerFactory)
        {
            _productService = productService;
        }

        [RouteMVC.HttpGet]
        public async Task<IActionResult> ListProducts()
        {
            var result = await _productService.GetAll();
            return Ok(result);
        }

        [RouteMVC.HttpGet]
        [RouteMVC.Route("product/"+RouteParams.ProductId)]
        public async Task<IActionResult> GetProduct([FromRoute]Guid productId)
        {
            return Ok(await _productService.GetById(productId));
        }

        [RouteMVC.HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> AddProduct([FromForm]Product modal)
        {
            modal.Id = Guid.NewGuid();
            await _productService.Create(modal);
            return Ok(modal);
        }

        [RouteMVC.HttpPatch]
        [RouteMVC.Route("product/" + RouteParams.ProductId)]
        public async Task<IActionResult> UpdateProduct([FromForm] Product modal, [FromRoute] Guid productId)
        {
            await _productService.Update(productId, modal);
            return Ok();
        }

        [RouteMVC.HttpDelete]
        [RouteMVC.Route("product/" + RouteParams.ProductId)]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid productId)
        {
            await _productService.Delete(productId);
            return Ok();
        }
    }
}
