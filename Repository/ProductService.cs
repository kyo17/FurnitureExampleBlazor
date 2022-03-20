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
    public class ProductService : IProduct
    {
        private readonly IDbConnection db;

        public ProductService(IDbConnection db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Product>> getByCategory(int categoryId)
        {
            var query = @"SELECT Id, Name, Price, CategoryId
                          FROM Products
                          WHERE CategoryId = @Id";
            return await db.QueryAsync<Product>(query, new{Id = categoryId});
        }
    }
}