namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts
{
    public class CartItemResponse
    {
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
