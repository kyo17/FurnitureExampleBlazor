using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
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
        private readonly IOrderProduct orderProductRepo;

        public OrderController(IOrder repo, IOrderProduct orderProductRepo)
        {
            this.repo = repo;
            this.orderProductRepo = orderProductRepo;
        }

        [HttpPost]
        public async Task<IActionResult> createOrder([FromBody] Order order)
        {
            if (order is null)
            {
                return BadRequest();
            }
            order.Id = await repo.getNextId();
            var response = false;
            using (var tnx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = await repo.createOrder(order);
                if (order.Products.Count > 0 && order.Products.Any())
                {
                    foreach (var prod in order.Products)
                    {
                        await orderProductRepo.createOrderProduct(order.Id, prod);
                    }
                }
                if (result)
                {
                    response = true;
                }
                tnx.Complete();
            }

            return Created("Created", response);
        }

        [HttpGet("getnextvalue")]
        public async Task<IActionResult> getNextOrderNum()
        {
            return Ok(await repo.getNextOrderNum());
        }
    }
}