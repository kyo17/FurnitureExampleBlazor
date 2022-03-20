using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Interfaces;
using Shared;

namespace Client.Services
{
    public class ServiceProduct : IProduct
    {
        private readonly HttpClient http;
        private readonly IConfiguration config;
        private readonly string apiUrl;

        public ServiceProduct(HttpClient http, IConfiguration config)
        {
            this.http = http;
            this.config = config;
            apiUrl = config.GetConnectionString("ApiUrl");
        }

        public async Task<IEnumerable<Product>> getByCategory(int categoryId)
        {
            return await http
            .GetFromJsonAsync<IEnumerable<Product>>($"{apiUrl}/getcategory/{categoryId}");
        }
    }
}