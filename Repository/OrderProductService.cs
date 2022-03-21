using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Interfaces;
using Shared;

namespace Repository
{
    public class OrderProductService : IOrderProduct
    {
        private readonly IDbConnection db;

        public OrderProductService(IDbConnection db)
        {
            this.db = db;
        }

        public async Task<bool> createOrderProduct(int orderId, Product product)
        {
            var ok = false;
            var query = @"INSERT INTO OrderProducts(OrderId, ProductId, Quantity)
                        VALUES(@OrderId, @ProductId, @Quantity)";
            var result = await db.ExecuteAsync(query, new {
                orderId = orderId,
                ProductId = product.Id,
                product.Quantity
            });
            if (result > 0)
            {
                ok = true;
            }
            return ok;
        }
    }
}