namespace CostSplitterAPI.Models
{
    public class Bill
    {
        public Guid BillId { get; set; }

        public Guid UserId { get; set; }    

        //public List<Participant> Participants { get; set; }

        //public List<SingleCost> SingleCosts { get; set; }

        public decimal TotalCost { set; get; }
    }
}
