using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AssessmentDemo.Foundation.Interfaces;
using AssessmentDemo.Foundation.Model;
using NetFrameworkWebAPI.Filters;

namespace NetFrameworkWebAPI.Controllers
{
    public class GiftsController : ApiController
    {
        private readonly IGiftsService _giftsService;

        private static readonly ICollection<Gift> Gifts = new List<Gift>
        {
            new Gift { Id = 0, Name = "Eco aroma candle", Price = 26 },
            new Gift { Id = 1, Name = "Wrist watch", Price = 100 },
            new Gift { Id = 2, Name = "Chocolate cake baking set", Price = 30 }
        };


        public GiftsController(IGiftsService giftsService)
        {
            _giftsService = giftsService;
        }


        public IEnumerable<Gift> Get()
        {
            return Gifts;
        }

        public Gift Get(int id)
        {
            var gift = Gifts.FirstOrDefault(g => g.Id == id);

            return gift;
        }

        public IEnumerable<Gift> Get(string recipientName)
        {
            return Gifts.Where(g => g.Recipient?.Name == recipientName).ToList();
        }

        [PriceFilter]
        public Gift Post(Gift gift)
        {
            gift.Id = Gifts.Count;
            Gifts.Add(gift);

            return gift;
        }
    }
}