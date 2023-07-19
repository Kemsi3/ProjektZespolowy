using CostSplitterAPI.Data;
using CostSplitterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CostSplitterAPI.Services.Transactions
{
    public class TransactionService :ITransactionService
    {
        public readonly DataContext _context;

        public TransactionService(DataContext context)
        {
            _context = context;
        }

        public async Task<IResult> AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return Results.Created($"/transaction/{transaction.TransactionId}", transaction);
        }

        public async Task<IResult> GetTransactionsByBillId(Guid billId)
        {
            return Results.Ok(await _context.Transactions.Where(t => t.BillId == billId).ToListAsync());
        }

    }
}
