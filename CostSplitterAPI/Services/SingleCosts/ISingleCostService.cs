using CostSplitterAPI.Models;

namespace CostSplitterAPI.Services.SingleCosts
{
    public interface ISingleCostService
    {
        Task<IResult> AddSingleCost(SingleCost singleCost);

        Task<IResult> GetSingleCostsByBillId(Guid billId);
    }
}
