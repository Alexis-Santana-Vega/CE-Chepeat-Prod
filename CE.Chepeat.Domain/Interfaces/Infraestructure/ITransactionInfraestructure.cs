using CE.Chepeat.Domain.Aggregates.Transaction;
using CE.Chepeat.Domain.DTOs.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Domain.Interfaces.Infraestructure
{
    public interface ITransactionInfraestructure
    {
        Task<List<SalesHistory>> GetSalesHistoryBySeller(Guid idSeller);
        Task<List<TransactionDto>> GetTransactionsByBuyer(Guid id);
        Task<List<TransactionDto>> GetTransactionsBySeller(Guid id);
        /// <summary>
        /// Agrega una nueva transacción
        /// </summary>
        Task<RespuestaDB> AddTransaction(TransactionRequest transactionAggregate);

        /// <summary>
        /// Obtiene el estado de una transacción
        /// </summary>
        Task<RespuestaDB> GetTransactionStatus(Guid idTransaction);

        Task<RespuestaDB> CompleteTransaction(TransactionCompleteRequest request);
    }
}

