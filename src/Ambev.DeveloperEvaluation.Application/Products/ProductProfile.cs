using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Domain.Entities.Product, Application.Products.ProductResult>();

            CreateMap<Application.Products.CreateProduct.CreateProductCommand, Domain.Entities.Product>();
            CreateMap<Application.Products.UpdateProduct.UpdateProductCommand, Domain.Entities.Product>();
        }
    }
}
