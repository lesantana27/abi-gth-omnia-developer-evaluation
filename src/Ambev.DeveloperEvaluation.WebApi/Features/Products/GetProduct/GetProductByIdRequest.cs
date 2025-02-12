namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct
{
    /// <summary>
    /// Request model for getting a product by ID
    /// </summary>
    /// 
    public class GetProductByIdRequest
    {
        /// <summary>
        /// Identificador do produto
        /// </summary>
        public Guid Id { get; set; }
    }
}
