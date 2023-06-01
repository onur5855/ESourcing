using ESourcing.sourcing.Data.Interfaces;
using ESourcing.sourcing.Entities;
using ESourcing.sourcing.Settings;
using MongoDB.Driver;

namespace ESourcing.sourcing.Data
{
    public class SourcingContext : ISourcingContext
    {
        public SourcingContext(ISourcingDatabaseSettings sourcingDatabaseSettings)
        {
            var client= new MongoClient(sourcingDatabaseSettings.ConnectionString);
            var database = client.GetDatabase(sourcingDatabaseSettings.DatabaseName);
            Auctions = database.GetCollection<Auction>(nameof(Auction));
            Bids = database.GetCollection<Bid>(nameof(Bid));
            SourcingContextSeed.SeedData(Auctions);//fake data ile gelicek
        }
        public IMongoCollection<Bid> Bids { get; }

        public IMongoCollection<Auction> Auctions { get; }
    }
}
