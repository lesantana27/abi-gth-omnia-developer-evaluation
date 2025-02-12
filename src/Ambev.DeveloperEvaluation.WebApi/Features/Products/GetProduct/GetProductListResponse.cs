using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct
{
    /// <summary>
    /// API response model for GetProductList operation
    /// </summary>
    public class GetProductListResponse
    {
        /// <summary>
        /// Lista de produtos
        /// </summary>
        public List<ProductResponse> ProductList { get; set; } = new List<ProductResponse>();


    }
}
