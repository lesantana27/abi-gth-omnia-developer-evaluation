namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct
{
    public class UpdateProductRequest: ProductRequest
    {
        /// <summary>
        /// Identificador do produto
        /// </summary>
        public Guid Id { get; set; }
    }
}
