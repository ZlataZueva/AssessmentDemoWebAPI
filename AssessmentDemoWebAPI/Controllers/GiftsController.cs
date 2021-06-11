using System.Collections.Generic;
using System.Linq;
using AssessmentDemo.Foundation.Model;
using AssessmentDemoWebAPI.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace AssessmentDemoWebAPI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class GiftsController : ControllerBase
    {
        private readonly ILogger<GiftsController> _logger;

        private static readonly ICollection<Gift> Gifts = new List<Gift>
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
        public IActionResult GetById(int id)
        {
            _logger.LogInformation("Getting gift with {id}", id);
            var gift = Gifts.FirstOrDefault(g => g.Id == id);
            if (gift == null)
            {
                return NotFound();
            }

            return Ok(gift);
        }

        [HttpGet("{recipientName:alpha}")]
        public ActionResult<IReadOnlyCollection<Gift>> GetByRecipient(string recipientName)
        {
            return Gifts.Where(g => g.Recipient?.Name == recipientName).ToList();
        }

        [HttpPost]
        [ServiceFilter(typeof(PriceFilter))]
        public IActionResult Add([BindRequired] Gift gift)
        {
            gift.Id = Gifts.Count;
            Gifts.Add(gift);

            return CreatedAtAction(nameof(GetById), new {id = gift.Id}, gift);
        }
    }
}