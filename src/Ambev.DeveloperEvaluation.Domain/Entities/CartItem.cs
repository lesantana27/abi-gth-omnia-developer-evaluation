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
        /// Identificador do produto
        /// </summary>
        public Guid ProductID { get; set; }

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
        /// Disconto do produto
        /// </summary>
        public decimal Discount { get; set; } = 0;

        /// <summary>
        /// Valor total do item, já calculado com o desconto
        /// </summary>
        public decimal TotalAmount { get; set; } = 0;

        /// <summary>
        /// Item excluido/cancelado do carrinho de compras
        /// </summary>
        public bool ItemCanceled { get; set; } = false;
    }
}
