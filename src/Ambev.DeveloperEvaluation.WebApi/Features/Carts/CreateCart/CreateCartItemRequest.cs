namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    public class CreateCartItemRequest
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
