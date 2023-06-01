using ESourcing.sourcing.Data.Interfaces;
using ESourcing.sourcing.Entities;
using ESourcing.sourcing.Repository.Interfaces;
using MongoDB.Driver;

namespace ESourcing.sourcing.Repository
{
    public class BidRepository : IBidRepository
    {
        private readonly ISourcingContext _sourcingContext;

        public BidRepository(ISourcingContext sourcingContext)
        {
            _sourcingContext = sourcingContext;
        }
        public async Task<List<Bid>> GetBidsAuctionId(string id)
        {
            MongoDB.Driver.FilterDefinition<Bid> filter = Builders<Bid>.Filter.Eq(a => a.Id, id);
            List<Bid> bids = await _sourcingContext.Bids.Find(filter).ToListAsync();
            bids = bids.OrderByDescending(a=>a.CreatedDate)
                .GroupBy(a=>a.SellerUserName)
                .Select(a=> new Bid
                {
                    AuctionId=a.FirstOrDefault().AuctionId,
                    Price=a.FirstOrDefault().Price,
                    CreatedDate = a.FirstOrDefault().CreatedDate,
                    SellerUserName = a.FirstOrDefault().SellerUserName,
                    ProductId = a.FirstOrDefault().ProductId,
                    Id = a.FirstOrDefault().Id
                }).ToList();
            return bids;
        }

        public async Task<Bid> GetWinner(string id)
        {
            List<Bid> bids = await GetBidsAuctionId(id);
            return bids.OrderByDescending(a => a.Price).FirstOrDefault();
        }

        public async Task SendBid(Bid id)
        {
           await _sourcingContext.Bids.InsertOneAsync(id);
        }
    }
}
