using System.Collections.Generic;
using System.Linq;
using AssessmentDemo.Foundation.Interfaces;
using AssessmentDemo.Foundation.Model;

namespace AssessmentDemo.Foundation.Services
{
    public class GiftsService : IGiftsService
    {
        private readonly IAmUseless _useless;


        public GiftsService(IAmUseless useless)
        {
            _useless = useless;
        }


        public double GetTotalGiftsCost(IReadOnlyCollection<Gift> gifts)
        {
            return gifts.Sum(g => g.Price);
        }
    }
}