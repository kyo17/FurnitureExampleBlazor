using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FurnitureExample.Shared;
using Interfaces;

namespace Client.Services
{
    public class ServiceOrder : IOrder
    {
        private readonly HttpClient http;
        private readonly IConfiguration config;
        private readonly string apiUrl;

        public ServiceOrder(HttpClient http, IConfiguration config)
        {
            this.http = http;
            this.config = config;
            apiUrl = config.GetConnectionString("ApiUrl");
        }

        public async Task<bool> createOrder(Order order)
        {
            var ok = false;
            var response = await http.PostAsJsonAsync<Order>($"{apiUrl}/order", order);
            if (response.IsSuccessStatusCode)
            {
                ok = true;
            }
            return ok;
        }

        public Task<int> getNextId()
        {
            throw new NotImplementedException();
        }

        public async Task<int> getNextOrderNum()
        {
            return await http.GetFromJsonAsync<int>($"{apiUrl}/getnextvalue");
        }
    }
}