using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartItemCommand : IRequest<CartItemResult>
    {
        /// <summary>
        /// Identificador do produto
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Quantidade a ser comprada do produto
        /// </summary>
        public int Quantity { get; set; } = 0;
    }
}
