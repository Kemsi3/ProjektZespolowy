namespace CostSplitterAPI.Models
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }

        public Guid BillId { get; set; }

        public Guid SenderId { get; set; }  

        public Guid ReceiverId { get; set; }

        public decimal Value { get; set; }
    }
}
