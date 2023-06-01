using ESourcing.Products.Data.Interfaces;
using ESourcing.Products.Entities;
using ESourcing.Products.Repository.Interfaces;
using MongoDB.Driver;

namespace ESourcing.Products.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductContext _productContext;

        public ProductRepository(IProductContext productContext)
        {
            _productContext = productContext;
        }
        public async Task Create(Product product)
        {
            await _productContext.Products.InsertOneAsync(product);
        }

        public async Task<bool> Delete(string Id)
        {
            var filter = Builders<Product>.Filter.Eq(a => a.Id, Id);
            DeleteResult deleteResult = await _productContext.Products.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string CategoryName)
        {
            var filter = Builders<Product>.Filter.Eq(a => a.Category, CategoryName);
            return await _productContext.Products.Find(filter).ToListAsync();
        }

        public async Task<Product> GetProductById(string Id)
        {
            return await _productContext.Products.Find(a => a.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string Name)
        {
            var filter = Builders<Product>.Filter.Eq(a => a.Category, Name);
            return await _productContext.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productContext.Products.Find(a => true).ToListAsync();
        }

        public async Task<bool> Update(Product product)
        {
            var updateResult = await _productContext.Products.ReplaceOneAsync(filter: a => a.Id == product.Id, replacement: product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
