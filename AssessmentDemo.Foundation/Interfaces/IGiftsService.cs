using System.Collections.Generic;
using AssessmentDemo.Foundation.Model;

namespace AssessmentDemo.Foundation.Interfaces
{
    public interface IGiftsService
    {
        double GetTotalGiftsCost(IReadOnlyCollection<Gift> gifts);
    }
}