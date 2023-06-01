using ESourcing.sourcing.Entities;

namespace ESourcing.sourcing.Repository.Interfaces
{
    public interface IBidRepository
    {
        Task SendBid(Bid id);
        Task<List<Bid>> GetBidsAuctionId(string id);
        Task<Bid> GetWinner( string id);
    }
}
