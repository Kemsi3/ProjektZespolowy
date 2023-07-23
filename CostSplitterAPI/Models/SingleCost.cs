namespace CostSplitterAPI.Models
{
    public class SingleCost
    {
        public Guid SingleCostId { get; set; }

        public Guid BillId { get; set; }

        public Guid ParticipantId { get; set; }

        public string Description { get; set; }    

        public decimal Cost { get; set; }
    }
}
