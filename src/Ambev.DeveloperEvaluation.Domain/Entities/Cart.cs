using Ambev.DeveloperEvaluation.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Classe wue representa o carrinho de compras
    /// </summary>
    public class Cart : BaseEntity
    {
        /// <summary>
        /// Número da Venda, inteiro aleatório, não repete
        /// </summary>
        public int SaleNumber { get; set; } = 0;


        //  Date when the sale was made
        /// <summary>
        /// Data da Venda
        /// </summary>
        public DateTime Date { get; set; } = DateTime.Now;


        /// <summary>
        /// Cliente que está comprando os produtos
        /// </summary>
        public Guid UserID { get; set; }

        //  Total sale amount
        /// <summary>
        /// Valor total do carrinho de compras
        /// </summary>
        public decimal TotalAmount { get; set; } = 0;

        /// <summary>
        /// Nome da filial onde a venda foi efetuada
        /// </summary>
        public string BranchName { get; set; } = string.Empty;

        //  Products
        /// <summary>
        /// Lista de produtos do carrinho de compras
        /// </summary>
        public List<CartItem> CartItemList { get; set; } = new List<CartItem>();





    }
}
