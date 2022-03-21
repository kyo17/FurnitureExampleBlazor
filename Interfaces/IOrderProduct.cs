using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared;

namespace Interfaces
{
    public interface IOrderProduct
    {
        Task<bool> createOrderProduct(int orderId, Product product);
    }
}