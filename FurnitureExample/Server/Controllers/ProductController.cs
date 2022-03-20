using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProduct repo;

        public ProductController(IProduct repo)
        {
            this.repo = repo;
        }

        [HttpGet("getbycategory/{id}")]
        public async Task<IActionResult> getByCategory(int cateegoryId){
            return Ok(await repo.getByCategory(cateegoryId));
        }
    }
}