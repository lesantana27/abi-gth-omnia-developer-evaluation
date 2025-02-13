namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    public class CreateCartRequest
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
        public List<CreateCartItemRequest> CartItemList { get; set; } = new List<CreateCartItemRequest>();

    }
}
