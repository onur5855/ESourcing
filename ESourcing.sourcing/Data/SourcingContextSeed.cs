using ESourcing.sourcing.Entities;
using MongoDB.Driver;

namespace ESourcing.sourcing.Data
{
    public class SourcingContextSeed
    {
        public static void SeedData(IMongoCollection<Auction> productCollection)
        {
            bool existProduct = productCollection.Find(a => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetConfigureAuctions());
            }
        }
        private static IEnumerable<Auction> GetConfigureAuctions()
        {
            return new List<Auction>()
            {
                new Auction()
                {
                  Name ="Auction1",
                  Description ="Açıklama 1",
                  StartDate =DateTime.Now,
                  FinishDate =DateTime.Now,
                  CreatedDate =DateTime.Now,
                  Status= (int)Status.Active,
                  Quantity= 5,
                  IncludedSellers =new List<string>()
                    {
                       "sellertest1@gmail.com",
                       "sellertest2@gmail.com",
                       "sellertest3@gmail.com"
                    }
                },
                new Auction()
                {
                     Name ="Auction2",
                  Description ="Açıklama 2",
                  StartDate =DateTime.Now,
                  FinishDate =DateTime.Now,
                  CreatedDate =DateTime.Now,
                  Status= (int)Status.Active,
                  Quantity= 9,
                  IncludedSellers =new List<string>()
                    {
                       "sellertest4@gmail.com",
                       "sellertest5@gmail.com",
                       "sellertest6@gmail.com"
                    }
                },
                new Auction()
                {
                     Name ="Auction3",
                  Description ="Açıklama 3",
                  StartDate =DateTime.Now,
                  FinishDate =DateTime.Now,
                  CreatedDate =DateTime.Now,
                  Status= (int)Status.Active,
                  Quantity= 9,
                  IncludedSellers =new List<string>()
                    {
                       "sellertest7@gmail.com",
                       "sellertest8@gmail.com",
                       "sellertest9@gmail.com"
                    }
                }

            };

        }
    }
}
