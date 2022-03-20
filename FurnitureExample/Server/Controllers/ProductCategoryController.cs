using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureExample.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategory repo;

        public ProductCategoryController(IProductCategory repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            return Ok(await repo.getAllProductsCategory());
        }
    }
}
