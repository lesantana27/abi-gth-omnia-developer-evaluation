using Ambev.DeveloperEvaluation.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    public class CreateProductResponse
    {
        /// <summary>
        /// Identificador do produto
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Título (nome) do produto
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Preço unitário
        /// </summary>
        public decimal Price { get; set; } = 0;

        /// <summary>
        /// Descrição do produto
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Categoria do produto
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Link da imagem do produto
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// Avaliação do produto
        /// </summary>
        public Rating Rating { get; set; } = new Rating();
    }
}
