using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        /// <summary>
        /// Identificador do carrinho de compras
        /// </summary>
        public Guid CartId { get; set; }

        /// <summary>
        /// Identificador do produto
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Título (nome) do produto
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Preço unitário
        /// </summary>
        public decimal Price { get; set; } = 0;

        /// <summary>
        /// Quantidade a ser comprada do produto
        /// </summary>
        public int Quantity { get; set; } = 0;

        /// <summary>
        /// Desconto do produto
        /// </summary>
        public decimal Discount
        {
            get { return DiscountCalculator(); }
            set { }
        }

        /// <summary>
        /// Valor total do item, já calculado com o desconto
        /// </summary>
        public decimal TotalAmount
        {
            get { return TotalAmountCalculator(); }
            set { }
        }

        /// <summary>
        /// Item excluido/cancelado do carrinho de compras
        /// </summary>
        public bool ItemCanceled { get; set; } = false;

        public Cart Cart { get; set; } = null!;


        private decimal DiscountCalculator()
        {
            if (Quantity >= 10) return 0.2M;    //  20%
            if (Quantity >= 04) return 0.1M;    //  10%

            return 0;
        }

        private decimal TotalAmountCalculator()
        {
            decimal total = Quantity * Price;

            return total - (total * Discount);
        }
    }
}
