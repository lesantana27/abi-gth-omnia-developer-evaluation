using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly DefaultContext _context;


        public CartRepository(DefaultContext context)
        {
            _context = context;
        }


        public async Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default)
        {
            await _context.Carts.AddAsync(cart, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return cart;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var cart = await GetByIdAsync(id, cancellationToken);
            if (cart == null)
                return false;

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<Cart>?> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Carts.Select(a => a).ToListAsync();
        }

        public async Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Carts.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }

        public async Task<Cart?> UpdateAsync(Cart cart, CancellationToken cancellationToken = default)
        {
            var cartExists = await _context.Carts.AsNoTracking().FirstOrDefaultAsync(a => a.Id == cart.Id, cancellationToken);
            if (cartExists == null)
                return null;

            _context.Carts.Update(cart);
            await _context.SaveChangesAsync(cancellationToken);

            return cart;
        }
    }
}
