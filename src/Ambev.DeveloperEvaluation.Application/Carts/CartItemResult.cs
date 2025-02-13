using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Carts
{
    public class CartItemResult
    {
        public Guid ProductId { get; set; }

        public string Title { get; set; } = string.Empty;

        public decimal Price { get; set; } = 0;

        public int Quantity { get; set; } = 0;

        public decimal Discount { get; set; } = 0;

        public decimal TotalAmount { get; set; } = 0;

        public bool ItemCanceled { get; set; } = false;
    }
}
