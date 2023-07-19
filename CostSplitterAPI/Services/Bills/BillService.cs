using CostSplitterAPI.Data;
using CostSplitterAPI.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IResult> GetBillsByUserId(Guid userId)
        {
            return Results.Ok(await _context.Bills.Where(b => b.UserId == userId).ToListAsync());
        }
    }
}
