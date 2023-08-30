using APIforPI.Infrastracture.Models;

namespace APIforPI.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
