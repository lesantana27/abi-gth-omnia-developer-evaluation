using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Avaliação do produto
    /// </summary>
    public class Rating
    {
        /// <summary>
        /// Nota da avaliação
        /// </summary>
        public decimal Rate { get; set; } = 0;

        /// <summary>
        /// Quantidade de avaliações
        /// </summary>
        public int Count { get; set; } = 0;
    }
}
