using Ambev.DeveloperEvaluation.Application.Products;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class CreateProductHandlerTests
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly CreateProductHandler _handler;


        public CreateProductHandlerTests()
        {
            _productRepository = Substitute.For<IProductRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CreateProductHandler(_productRepository, _mapper);
        }


        [Fact(DisplayName = "Criar um produto - retorno sucesso")]
        public async Task CriarProdutoComRetornoSucesso()
        {
            // Given
            var command = CreateProductHandlerTestData.GenerateValidCommand();
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Title = command.Title,
                Price = command.Price,
                Description = command.Description,
                Category = command.Category,
                Image = command.Image,
                RatingRate = command.RatingRate,
                RatingCount = command.RatingCount
            };

            var result = new ProductResult
            {
                Id = product.Id,
            };


            _mapper.Map<Product>(command).Returns(product);
            _mapper.Map<ProductResult>(product).Returns(result);

            _productRepository.CreateAsync(Arg.Any<Product>(), Arg.Any<CancellationToken>())
                .Returns(product);


            // When
            var createProductResult = await _handler.Handle(command, CancellationToken.None);

            // Then
            createProductResult.Should().NotBeNull();
            createProductResult.Id.Should().Be(product.Id);
            await _productRepository.Received(1).CreateAsync(Arg.Any<Product>(), Arg.Any<CancellationToken>());
        }


        [Fact(DisplayName = "Criar um produto - retorno erro")]
        public async Task CriarProdutoComRetornoErro()
        {
            // Given
            var command = new CreateProductCommand();
            command.Title = "a";

            // When
            var act = () => _handler.Handle(command, CancellationToken.None);

            // Then
            await act.Should().ThrowAsync<System.NullReferenceException>();
        }
    }
}
