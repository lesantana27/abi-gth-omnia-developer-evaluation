﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Repository interface for Product entity operations
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Creates a new product in the repository
        /// </summary>
        /// <param name="product">The product to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created product</returns>
        Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a product by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The product if found, null otherwise</returns>
        Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all products by category
        /// </summary>
        /// <param name="category">The category to search for</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The product if found, null otherwise</returns>
        Task<List<Product>?> GetByCategoryAsync(string category, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all categories
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The list of categories if found, null otherwise</returns>
        Task<List<string>?> GetAllCategoriesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a product from the repository
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the product was deleted, false if not found</returns>
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
