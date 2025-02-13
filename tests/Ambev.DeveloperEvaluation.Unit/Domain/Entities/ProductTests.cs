using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    /// <summary>
    /// Testes unitários da entidade de domínio Product
    /// </summary>
    public class ProductTests
    {
        [Fact(DisplayName = "Produto válido")]
        public void ProdutoValido()
        {
            var product = ProductTestData.GenerateValidProduct();

            // Act
            var result = product.Validate();

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact(DisplayName = "Produto inválido - Título pequeno")]
        public void ProdutoInvalidoTituloPequeno()
        {
            var product = ProductTestData.GenerateInvalidTitleSmall();

            // Act
            var result = product.Validate();

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }

        [Fact(DisplayName = "Produto inválido - Título grande")]
        public void ProdutoInvalidoTituloGrande()
        {
            var product = ProductTestData.GenerateInvalidTitleBig();

            // Act
            var result = product.Validate();

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }

        [Fact(DisplayName = "Produto inválido - Preço negativo")]
        public void ProdutoInvalidoPrecoNegativo()
        {
            var product = ProductTestData.GenerateInvalidPrice();

            // Act
            var result = product.Validate();

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }

        [Fact(DisplayName = "Produto inválido - Avaliação menor que zero")]
        public void ProdutoInvalidoAvaliacaoNegativa()
        {
            var product = ProductTestData.GenerateInvalidRatingRateNegative();

            // Act
            var result = product.Validate();

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }

        [Fact(DisplayName = "Produto inválido - Avaliação maior que 5")]
        public void ProdutoInvalidoAvaliacaoPositiva()
        {
            var product = ProductTestData.GenerateInvalidRatingRatePositive();

            // Act
            var result = product.Validate();

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }

        [Fact(DisplayName = "Produto inválido - Quantidade de avaliações menor que zero")]
        public void ProdutoInvalidoQuantidadeAvaliacaoNegativa()
        {
            var product = ProductTestData.GenerateInvalidRatingCountNegative();

            // Act
            var result = product.Validate();

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }
    }
}
