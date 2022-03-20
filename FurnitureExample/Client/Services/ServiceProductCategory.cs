using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FurnitureExample.Shared;
using Interfaces;

namespace Client.Services
{
    public class ServiceProductCategory : IProductCategory
    {
        private readonly HttpClient http;
        private readonly IConfiguration config;

        private readonly string apiUrl;

        public ServiceProductCategory(HttpClient http, IConfiguration config)
        {
            this.http = http;
            this.config = config;
            apiUrl = config.GetConnectionString("ApiUrl");
        }

        public async Task<IEnumerable<ProductCategory>> getAllProductsCategory()
        {
            return await http.GetFromJsonAsync<IEnumerable<ProductCategory>>($"{apiUrl}/productcategory");
        }
    }
}