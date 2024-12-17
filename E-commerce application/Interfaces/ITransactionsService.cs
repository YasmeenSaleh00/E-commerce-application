using E_commerce_application.DTOs.Transaction.Request;
using E_commerce_application.DTOs.Transaction.Response;

namespace E_commerce_application.Interfaces
{
    public interface ITransactionsService
    {
        Task CreateTransaction(CreateTransactionDTO input);
        Task<List<TransactionDTO>> ReadAllTransaction();
    }
}
