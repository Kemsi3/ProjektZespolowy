namespace CostSplitterAPI.Models
{
    public class Participant
    {
        public Guid ParticipantId { get; set; }

        public Guid BillId { get; set; }

        public string Name { get; set; }   

        public decimal Balance { get; set; }

    }
}
