using ESourcing.sourcing.Entities;
using ESourcing.sourcing.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ESourcing.sourcing.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly ILogger<AuctionController> _logger;

        public AuctionController(IAuctionRepository auctionRepository,ILogger<AuctionController> logger)
        {
            _auctionRepository = auctionRepository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Auction>),(int)HttpStatusCode.OK)] //[ProducesResponseType(typeof(IEnumerable<Auction>),200)]
        public async Task<ActionResult <IEnumerable<Auction>>> GetActions()
        {
            return Ok( await _auctionRepository.GetAuctions());
        }

        [HttpGet("{id:length(24)}", Name = "GetAction")]
        [ProducesResponseType(typeof(Auction), (int)HttpStatusCode.OK)] //200
        [ProducesResponseType((int)HttpStatusCode.NotFound)] //404
        public async Task<ActionResult<Auction>> GetAction(string id)
        {
            var auction = await _auctionRepository.GetAuction(id);
            if (auction==null)
            {
                _logger.LogError($"auction with id: {id} , hasn't been  found in database.");
                return NotFound();
            }
            return Ok(auction);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Auction), (int)HttpStatusCode.Created)] //201
        public async Task<ActionResult<Auction>> CreateAuction([FromBody] Auction auction)
        {
             await _auctionRepository.Create(auction);
          
            return CreatedAtRoute("GetAction", new {id=auction.Id},auction);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Auction), (int)HttpStatusCode.OK)] //200
        public async Task<ActionResult<Auction>> UpdateAuction([FromBody] Auction auction)
        {
           return Ok( await _auctionRepository.Update(auction));
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(Auction), (int)HttpStatusCode.OK)] //200
        public async Task<ActionResult<Auction>> DeleteAuctionById( string id)
        {
            return Ok(await _auctionRepository.Delete(id));
        }


    }
}
