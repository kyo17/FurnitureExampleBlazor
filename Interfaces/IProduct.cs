using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared;

namespace Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> getByCategory(int categoryId);
    }
}