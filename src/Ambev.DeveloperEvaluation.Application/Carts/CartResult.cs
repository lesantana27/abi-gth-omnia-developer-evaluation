using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Carts
{
    public class CartResult
    {
        public Guid Id { get; set; }

        public long SaleNumber { get; set; } = DateTime.Now.Ticks;

        public DateTime Date { get; set; } = DateTime.Now;

        public Guid UserId { get; set; }

        public decimal TotalAmount { get; set; }

        public string BranchName { get; set; } = string.Empty;

        public List<CartItemResult> CartItemList { get; set; } = new List<CartItemResult>();
    }
}
