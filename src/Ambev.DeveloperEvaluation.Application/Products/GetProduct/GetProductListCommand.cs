using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    public class GetProductListCommand : IRequest<GetProductListResult>
    {

        /// <summary>
        /// Initializes a new instance of GetProductListCommand
        /// </summary>
        public GetProductListCommand()
        {
        }
    }
}
