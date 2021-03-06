using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FurnitureExample.Shared;
using Interfaces;

namespace Repository
{
    public class OrderService : IOrder
    {
        private readonly IDbConnection db;

        public OrderService(IDbConnection db)
        {
            this.db = db;
        }

        public async Task<bool> createOrder(Order order)
        {
            var Ok = false;
            var query =
            @"INSERT INTO Orders (OrderNumber, ClientId, OrderDate, DeliveryDate, Total)
              VALUES (@OrderNumber, @ClientId, @OrderDate, @DeliveryDate, @Total)";
            var result = await db.ExecuteAsync(query, new
            {
                order.OrderNumber,
                order.ClientId,
                order.OrderDate,
                order.DeliveryDate,
                order.Total
            });
            if (result > 0)
            {
                Ok = true;
            }
            return Ok;
        }

        public async Task<int> getNextId()
        {
            var query = @"SELECT IDENT_CURRENT('Orders') + 1";
            return await db.QueryFirstAsync<int>(query, new { });
        }

        public async Task<int> getNextOrderNum()
        {
            var query = @"SELECT MAX(OrderNumber) + 1
                        FROM Orders";
            return await db.QueryFirstAsync<int>(query, new { });
        }
    }
}