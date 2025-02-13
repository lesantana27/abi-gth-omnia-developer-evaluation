
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    /// <summary>
    /// Comando para criação de um produto
    /// </summary>
    public class UpdateProductCommand : IRequest<ProductResult>
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

        //public ValidationResultDetail Validate()
        //{
        //    var validator = new UpdateProductCommandValidator();
        //    var result = validator.Validate(this);
        //    return new ValidationResultDetail
        //    {
        //        IsValid = result.IsValid,
        //        Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        //    };
        //}
    }
}
