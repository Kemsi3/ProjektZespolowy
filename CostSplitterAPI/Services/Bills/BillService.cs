using CostSplitterAPI.Data;
using CostSplitterAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

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

        public async Task<IResult> DeleteBill(Guid billId)
        {
            Bill billToDelete = _context.Bills.Where(b => b.BillId == billId).FirstOrDefault();
            _context.Bills.Remove(billToDelete);
            _context.SaveChanges();
            return Results.Ok();
        }

        public async Task<IResult> GetBillsByUserId(Guid userId)
        {
            return Results.Ok(await _context.Bills.Where(b => b.UserId == userId).ToListAsync());
        }

        public async Task<IResult> SplitBill(Guid billId)
        {
            Bill billToSplit = _context.Bills.Where(b => b.BillId == billId).FirstOrDefault();

            List<Participant> participants = _context.Participants.Where(p => p.BillId == billId).ToList();

            List<SingleCost> singleCosts = _context.SingleCosts.Where(s => s.BillId == billId).ToList();

            List<Transaction> transactions = _context.Transactions.Where(s => s.BillId == billId).ToList();

            decimal totalCost = 0;
            
            foreach(SingleCost s in singleCosts)
            {
                totalCost += s.Cost;
            }

            decimal costPerParticipant = totalCost / participants.Count;

            foreach (Participant p in participants)
            {
                foreach (SingleCost s in singleCosts)
                {
                    if (s.ParticipantId == p.ParticipantId)
                    {
                        p.Balance += s.Cost;
                    }
                }

                p.Balance -= costPerParticipant;
            }

            _context.Bills.Update(billToSplit);
            _context.Participants.UpdateRange(participants);
            _context.SaveChanges();


            return Results.Ok(await _context.Participants.Where(p => p.BillId == billId).ToListAsync());
        }
    }
}
