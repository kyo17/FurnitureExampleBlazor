using Dapper;
using FurnitureExample.Shared;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductCategoryService : IProductCategory
    {
        private readonly IDbConnection db;

        public ProductCategoryService(IDbConnection db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<ProductCategory>> getAllProductsCategory()
        {
            var query = @"SELECT Id, Name FROM ProductCategories";
            return await db.QueryAsync<ProductCategory>(query, new {});
        }
    }
}
