using CostSplitterAPI.Models;
using System.Threading.Tasks;

namespace CostSplitterAPI.Services.Participants
{
    public interface IParticipantService
    {
        Task<IResult> AddParticipant(Participant participant);

        Task<IResult> GetParticipantsByBillId(Guid BillId);
    }
}
