using CostSplitterAPI.Data;
using CostSplitterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CostSplitterAPI.Services.Participants
{
    public class ParticipantService :IParticipantService
    {

        public readonly DataContext _context;

        public ParticipantService(DataContext context)
        {
            _context = context;
        }

        public async Task<IResult> AddParticipant(Participant participant)
        {
            _context.Participants.Add(participant);
            await _context.SaveChangesAsync();
            return Results.Created($"/participant/{participant.ParticipantId}", participant);
        }

        public async Task<IResult> DeleteParticipant(Guid participantId)
        {
            Participant participantToDelete = _context.Participants.Where(p => p.ParticipantId == participantId).FirstOrDefault();
            _context.Participants.Remove(participantToDelete);
            _context.SaveChanges();
            return Results.Ok();
        }
    

        public async Task<IResult> GetParticipantsByBillId(Guid billId)
        {
            return Results.Ok(await _context.Participants.Where(p => p.BillId == billId).ToListAsync());
        }
    }
}
