using CostSplitterAPI.Data;
using CostSplitterAPI.Models;

namespace CostSplitterAPI.Services.Bills
{
    public class BillService : IBillService
    {
        public readonly DataContext _context;

        public BillService(DataContext context)
        {
            _context = context;
        }

        public async Task<IResult> AddBill(Bill bill)
        {
            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();
            return Results.Created($"/bill/{bill.BillId}", bill);
        }
    }
}
