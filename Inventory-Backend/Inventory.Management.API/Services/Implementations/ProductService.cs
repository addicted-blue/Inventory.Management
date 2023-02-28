using Inventory.Management.API.Modals;
using Inventory.Management.API.Modals.Context;
using Inventory.Management.API.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Management.API.Services.Implementations
{
    public class ProductService : IProductService
    {
        private InventoryDbContext _context;

        public ProductService(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(Guid id)
        {
            return await GetProduct(id);
        }

        public async Task Create(Product model)
        {
            _context.Products.Add(model);
            _context.SaveChanges();
        }

        public async Task Update(Guid id, Product model)
        {
            var product = await GetProduct(id);
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public async Task Delete(Guid id)
        {
            var product = await GetProduct(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        private async Task<Product> GetProduct(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id.ToString() == id.ToString());
            if (product == null) 
                throw new KeyNotFoundException("User not found");

            return product;
        }
    }
}
