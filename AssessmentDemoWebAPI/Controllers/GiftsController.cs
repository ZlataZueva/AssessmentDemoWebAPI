using System.Collections.Generic;
using System.Linq;
using AssessmentDemo.Foundation.Model;
using AssessmentDemoWebAPI.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace AssessmentDemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftsController : ControllerBase
    {
        private readonly ILogger<GiftsController> _logger;

        private static readonly ICollection<Gift> Gifts = new[]
        {
            new Gift { Id = 0, Name = "Eco aroma candle", Price = 26 },
            new Gift { Id = 1, Name = "Wrist watch", Price = 100 },
            new Gift { Id = 2, Name = "Chocolate cake baking set", Price = 30 }
        };


        public GiftsController(ILogger<GiftsController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IReadOnlyCollection<Gift> Get()
        {
            _logger.LogInformation("Getting gifts");
            return Gifts.ToList();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Gift> Get(int id)
        {
            _logger.LogInformation("Getting gift with {id}", id);
            var gift = Gifts.FirstOrDefault(g => g.Id == id);

            return gift != null ? new ActionResult<Gift>(gift) : NotFound();
        }

        [HttpGet("{recipientName:alpha}")]
        public IReadOnlyCollection<Gift> Get(string recipientName)
        {
            return Gifts.Where(g => g.Recipient?.Name == recipientName).ToList();
        }

        [HttpPost]
        [ServiceFilter(typeof(PriceFilter))]
        public ActionResult<Gift> Add([FromBody][BindRequired] Gift gift)
        {
            gift.Id = Gifts.Count;
            Gifts.Add(gift);

            return new ActionResult<Gift>(gift);
        }
    }
}