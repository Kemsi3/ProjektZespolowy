namespace CostSplitterAPI.Models
{
    public class SingleCost
    {
        public Guid SingleCostId { get; set; }

        public Guid BillId { get; set; }

        public int ParticipantId { get; set; }

        public string Description { get; set; }    

        public decimal Cost { get; set; }
    }
}
