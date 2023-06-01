using ESourcing.Products.Entities;
using MongoDB.Driver;

namespace ESourcing.Products.Data
{
    public class ProductContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(a => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetConfigureProducts());
            }
        }

        private static IEnumerable<Product> GetConfigureProducts()
        {
            return new List<Product>()
            {
                  new Product()
                {
                    Name = "name",
                    Summary = "desc",
                    Description = "desc",
                    ImageFile="produck.jpg",
                    Price = 1,
                    Category="1. kategori"
                },
                  new Product()
                {
                    Name = "name2",
                    Summary = "desc",
                    Description = "desc",
                    ImageFile="produck.jpg",
                    Price = 7,
                    Category="2. kategori"
                },
                  new Product()
                {
                    Name = "name3",
                    Summary = "summarysi",
                    Description = "açıklması",
                    ImageFile="resim1.jpg",
                    Price = 3,
                    Category="5. kategori"
                }
            };
        }


    }
}
