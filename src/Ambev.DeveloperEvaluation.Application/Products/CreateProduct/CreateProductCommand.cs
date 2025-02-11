using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    /// <summary>
    /// Comando para criação de um produto
    /// </summary>
    public class CreateProductCommand : IRequest<CreateProductResult>
    {
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

        public ValidationResultDetail Validate()
        {
            var validator = new CreateProductCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
