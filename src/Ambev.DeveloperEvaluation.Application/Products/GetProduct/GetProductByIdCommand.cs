using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    public class GetProductByIdCommand : IRequest<ProductResult>
    {
        /// <summary>
        /// The unique identifier of the product to retrieve
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Initializes a new instance of GetProductByIdCommand
        /// </summary>
        /// <param name="id">The ID of the product to retrieve</param>
        public GetProductByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
