using ESourcing.sourcing.Entities;
using MongoDB.Driver;

namespace ESourcing.sourcing.Data.Interfaces
{
    public interface ISourcingContext
    {
        IMongoCollection<Bid> Bids { get; }
        IMongoCollection<Auction> Auctions { get; }
    }
}
