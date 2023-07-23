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
            Participant receiver = _context.Participants.Where(p => p.ParticipantId == transaction.ReceiverId).FirstOrDefault();

            Participant sender = _context.Participants.Where(p => p.ParticipantId == transaction.SenderId).FirstOrDefault();

            sender.Balance += transaction.Value;

            receiver.Balance -= transaction.Value;

            _context.Participants.Update(sender);
            _context.Participants.Update(receiver);
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return Results.Created($"/transaction/{transaction.TransactionId}", transaction);
        }

        public async Task<IResult> DeleteTransaction(Guid transactionId)
        {
            Transaction transactionToDelete = _context.Transactions.Where(t => t.TransactionId == transactionId).FirstOrDefault();
            _context.Transactions.Remove(transactionToDelete);
            _context.SaveChanges();
            return Results.Ok();
        }
    

        public async Task<IResult> GetTransactionsByBillId(Guid billId)
        {
            return Results.Ok(await _context.Transactions.Where(t => t.BillId == billId).ToListAsync());
        }

    }
}
