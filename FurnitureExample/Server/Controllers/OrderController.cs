using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurnitureExample.Shared;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrder repo;

        public OrderController(IOrder repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> createOrder([FromBody] Order order){
            if (order is null)
            {
                return BadRequest();
            }
            var response = false;
            var result = await repo.createOrder(order);
            if(result){
                response = true;
            }
            return Created("Created", response);
        }
    }
}