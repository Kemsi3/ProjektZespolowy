using CostSplitterAPI.Models;

namespace CostSplitterAPI.Services.Transactions
{
    public interface ITransactionService
    {
        Task<IResult> AddTransaction(Transaction transaction);
    }
}
