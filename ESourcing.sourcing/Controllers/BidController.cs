using ESourcing.sourcing.Entities;
using ESourcing.sourcing.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ESourcing.sourcing.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IBidRepository _bidRepository;

        public BidController(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]//200
        public async Task<ActionResult> SendBid([FromBody] Bid bid)
        {
            await _bidRepository.SendBid(bid);
            return Ok();
        }
        [HttpGet("GetBidByAuctionId")]
        [ProducesResponseType(typeof(IEnumerable<Bid>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Bid>>> GetBidByAuctionId(string id)
        {
            IEnumerable<Bid> bids= await _bidRepository.GetBidsAuctionId(id);
            return Ok(bids);
        }
        [HttpGet("GetWinnerBid")]
        [ProducesResponseType(typeof(Bid), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Bid>> GetWinnerBid(string id)
        {
            Bid bid = await _bidRepository.GetWinner(id);
            return Ok(bid);
        }



    }
}
