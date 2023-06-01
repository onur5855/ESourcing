using ESourcing.sourcing.Data.Interfaces;
using ESourcing.sourcing.Entities;
using ESourcing.sourcing.Repository.Interfaces;
using MongoDB.Driver;

namespace ESourcing.sourcing.Repository
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly ISourcingContext _sourcingContext;

        public AuctionRepository(ISourcingContext sourcingContext)
        {
            _sourcingContext = sourcingContext;
        }
        public async Task Create(Auction auction)
        {
          await _sourcingContext.Auctions.InsertOneAsync(auction);
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Auction> filter = Builders<Auction>.Filter.Eq( a=>a.Id ,id);
            DeleteResult delete= await _sourcingContext.Auctions.DeleteOneAsync(filter);
            return delete.IsAcknowledged && delete.DeletedCount > 0;
            // return delete!=null;
        }

        public async Task<Auction> GetAuction(string id)
        {
            return await _sourcingContext.Auctions.Find(a=>a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Auction> GetAuctionByName(string name)
        {
            FilterDefinition<Auction> filter = Builders<Auction>.Filter.Eq(a => a.Name, name);

            return await _sourcingContext.Auctions.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Auction>> GetAuctions()
        {
            return await _sourcingContext.Auctions.Find(a => true).ToListAsync();
        }

        public async Task<bool> Update(Auction auction)
        {
            var update = await _sourcingContext.Auctions.ReplaceOneAsync(a=>a.Id.Equals(auction.Id),auction);
            return update.IsAcknowledged && update.ModifiedCount>0;
        }
    }
}
