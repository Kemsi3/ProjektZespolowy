using CostSplitterAPI.Models;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CostSplitterAPI.Services.Participants
{
    public interface IParticipantService
    {
        Task<IResult> AddParticipant(Participant participant);

        Task<IResult> GetParticipantsByBillId(Guid billId);

        Task<IResult> DeleteParticipant(Guid participantId);
    }
}
