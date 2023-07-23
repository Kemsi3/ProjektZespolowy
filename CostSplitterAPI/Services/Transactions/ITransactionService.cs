using CostSplitterAPI.Models;
using System.Runtime.CompilerServices;

namespace CostSplitterAPI.Services.Transactions
{
    public interface ITransactionService
    {
        Task<IResult> AddTransaction(Transaction transaction);

        Task<IResult> GetTransactionsByBillId(Guid billId);

        Task<IResult> DeleteTransaction(Guid transactionId);
    }
}
