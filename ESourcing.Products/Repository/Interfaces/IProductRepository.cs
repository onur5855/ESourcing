using ESourcing.Products.Entities;

namespace ESourcing.Products.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(string Id);
        Task<IEnumerable<Product>> GetProductByCategory(string CategoryName);
        Task<IEnumerable<Product>> GetProductByName(string Name);
        Task Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(string Id);
    }
}
