namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts
{
    public class CartResponse
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Número da Venda, inteiro aleatório, não repete
        /// </summary>
        public long SaleNumber { get; set; } = DateTime.Now.Ticks;

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

        /// <summary>
        /// Lista de produtos do carrinho de compras
        /// </summary>
        public List<CartItemResponse> CartItemList { get; set; } = new List<CartItemResponse>();

    }
}
