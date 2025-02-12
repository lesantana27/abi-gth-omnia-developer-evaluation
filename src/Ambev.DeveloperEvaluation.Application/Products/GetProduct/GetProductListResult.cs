using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    public class GetProductListResult
    {
        /// <summary>
        /// Lista de produtos
        /// </summary>
        public List<ProductResult> ProductList { get; set; } = new List<ProductResult>();
    }
}
