using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Classe de Produtos, que será utilizada para cadastro e venda
    /// </summary>
    public class Product : BaseEntity, IProduct
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
        [NotMapped]
        public Rating Rating { get; set; } = new Rating();


        /// <summary>
        /// Somente para mapear a Nota da avaliação
        /// </summary>
        [JsonIgnore]
        public decimal RatingRate { get => Rating.Rate; set => Rating.Rate = value; }

        /// <summary>
        /// Somente para mapear a Quantidade de avaliações
        /// </summary>
        [JsonIgnore]
        public int RatingCount { get => Rating.Count; set => Rating.Count = value; }


        public FluentValidation.Results.ValidationResult Validate()
        {
            var validator = new ProductValidator();
           return validator.Validate(this);
        }
    }
}
