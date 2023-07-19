using CostSplitterAPI.Data;
using CostSplitterAPI.Models;

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
    }
}
