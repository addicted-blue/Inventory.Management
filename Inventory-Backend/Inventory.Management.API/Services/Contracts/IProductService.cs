using Inventory.Management.API.Modals;

namespace Inventory.Management.API.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid id);
        Task Create(Product model);
        Task Update(Guid id, Product model);
        Task Delete(Guid id);
    }
}
