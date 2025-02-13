using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartCommand : IRequest<CartResult>
    {
        /// <summary>
        /// Cliente que está comprando os produtos
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Nome da filial onde a venda foi efetuada
        /// </summary>
        public string BranchName { get; set; } = string.Empty;

        /// <summary>
        /// Lista de produtos do carrinho de compras
        /// </summary>
        public List<CreateCartItemCommand> CartItemList { get; set; } = new List<CreateCartItemCommand>();
    }
}
