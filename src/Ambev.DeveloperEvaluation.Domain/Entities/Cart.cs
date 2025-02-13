using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Classe wue representa o carrinho de compras
    /// </summary>
    public class Cart : BaseEntity
    {
        /// <summary>
        /// Número da Venda, inteiro aleatório, não repete
        /// </summary>
        public long SaleNumber { get; set; } = DateTime.Now.Ticks;

        /// <summary>
        /// Data da Venda
        /// </summary>
        public DateTime Date { get; set; } = DateTime.Now;

        /// <summary>
        /// Cliente que está comprando os produtos
        /// </summary>
        public Guid UserId { get; set; }

        //  Total sale amount
        /// <summary>
        /// Valor total do carrinho de compras
        /// </summary>
        public decimal TotalAmount
        {
            get { return CartItemList.Sum(a => a.TotalAmount); }
            set { }
        }

        /// <summary>
        /// Nome da filial onde a venda foi efetuada
        /// </summary>
        public string BranchName { get; set; } = string.Empty;

        /// <summary>
        /// Cliente que está comprando os produtos
        /// </summary>
        public User User { get; set; } = new User();


        /// <summary>
        /// Lista de produtos do carrinho de compras
        /// </summary>
        public List<CartItem> CartItemList { get; set; } = new List<CartItem>();

        public FluentValidation.Results.ValidationResult Validate()
        {
            var validator = new CartValidator();
            return validator.Validate(this);
        }
    }
}
