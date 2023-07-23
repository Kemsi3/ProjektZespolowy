using CostSplitterAPI.Models;

namespace CostSplitterAPI.Services.Bills
{
    public interface IBillService
    {
        Task<IResult> AddBill(Bill bill);

        Task<IResult> GetBillsByUserId(Guid userId);

        Task<IResult> SplitBill (Guid billId);

        Task<IResult> DeleteBill (Guid billId);
    }
}
