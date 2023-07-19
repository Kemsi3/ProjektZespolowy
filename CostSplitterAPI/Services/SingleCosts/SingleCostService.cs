using CostSplitterAPI.Data;
using CostSplitterAPI.Models;

namespace CostSplitterAPI.Services.SingleCosts
{
    public class SingleCostService : ISingleCostService
    {

        public readonly DataContext _context;

        public SingleCostService(DataContext context)
        {
            _context = context;
        }

        public async Task<IResult> AddSingleCost(SingleCost singleCost)
        {
            _context.SingleCosts.Add(singleCost);
            await _context.SaveChangesAsync();
            return Results.Created($"/singleCost/{singleCost.SingleCostId}", singleCost);
        }
    }
}
