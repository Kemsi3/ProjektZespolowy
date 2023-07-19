using CostSplitterAPI.Models;

namespace CostSplitterAPI.Services.Bills
{
    public interface IBillService
    {
        Task<IResult> AddBill(Bill bill);
    }
}
