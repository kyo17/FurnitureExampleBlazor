using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace FurnitureExample.Shared
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int ClientId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset DeliveryDate { get; set; }
        public decimal Total 
        { 
            get
            {
                decimal sum = 0;
                if (Products.Count > 0 && Products.Any())
                {
                    sum = Products.Sum(p => (p.Price * p.Quantity));
                }
                return sum;
            }
        }
        public int ProductCategoryId { get; set; }
        public List<Product> Products { get; set; }
    }
}
