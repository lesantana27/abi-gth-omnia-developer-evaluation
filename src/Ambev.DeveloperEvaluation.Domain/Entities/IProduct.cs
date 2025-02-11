using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    interface IProduct
    {
        /// <summary>
        /// Obtém a nota da avaliação
        /// </summary>
        /// <returns>A nota da avaliação.</returns>
        public decimal RatingRate { get; set; }

        /// <summary>
        /// Obtém a quantidade de avaliações
        /// </summary>
        /// <returns>A quantidade de avaliações.</returns>
        public int RatingCount { get; set; }


    }
}
