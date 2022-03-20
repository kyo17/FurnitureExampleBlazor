using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurnitureExample.Shared;

namespace Interfaces
{
    public interface IOrder
    {
        Task<bool> createOrder(Order order);
    }
}