namespace CostSplitterAPI.Models
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }

        public Guid BillId { get; set; }

        public int SenderId { get; set; }  

        public int ReceiverId { get; set; }

        public decimal Value { get; set; }
    }
}
