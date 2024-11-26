using CE.Chepeat.Domain.Aggregates.Transaction;
using CE.Chepeat.Domain.DTOs.PurchaseRequest;
using CE.Chepeat.Domain.DTOs.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Infraestructure.Repositories
{
    public class TransactionInfraestructure : ITransactionInfraestructure
    {
        private readonly ChepeatContext _context;

        public TransactionInfraestructure(ChepeatContext context)
        {
            _context = context;
        }
        public async Task<List<SalesHistory>> GetSalesHistoryBySeller(Guid idSeller)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("IdSeller", idSeller)
                };

                string sqlQuery = "EXEC dbo.SP_Transaction_SalesHistoryBySeller @IdSeller";
                var dataSP = await _context.SalesHistoy.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP;
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<List<TransactionDto>> GetTransactionsBySeller(Guid id)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("IdSeller", id)
                };

                string sqlQuery = "EXEC dbo.SP_Transaction_ViewBySeller @IdSeller";
                var dataSP = await _context.transactionDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP;
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<List<TransactionDto>> GetTransactionsByBuyer(Guid id)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("IdBuyer", id)
                };

                string sqlQuery = "EXEC dbo.SP_Transaction_ViewByBuyer @IdBuyer";
                var dataSP = await _context.transactionDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP;
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<RespuestaDB> AddTransaction(TransactionRequest transactionAggregate)
        {
            try
            {
                var NumError = new SqlParameter
                {
                    ParameterName = "NumError",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                var Result = new SqlParameter
                {
                    ParameterName = "Result",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Direction = ParameterDirection.Output
                };

                SqlParameter[] parameters =
                {
                new SqlParameter("IdPurchaseRequest", transactionAggregate.IdPurchaseRequest),
                NumError,
                Result
            };
                string sqlQuery = "EXEC dbo.SP_Transaction_Add @IdPurchaseRequest, @NumError OUTPUT, @Result OUTPUT";
                var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<RespuestaDB> CompleteTransaction(TransactionCompleteRequest request)
        {
            try
            {
                var NumError = new SqlParameter
                {
                    ParameterName = "NumError",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                var Result = new SqlParameter
                {
                    ParameterName = "Result",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Direction = ParameterDirection.Output
                };

                SqlParameter[] parameters =
                {
                new SqlParameter("Id", request.Id),
                new SqlParameter("WasDelivered", request.WasDelivered),
                new SqlParameter("WasPaid", request.WasPaid),
                NumError,
                Result
            };
                string sqlQuery = "EXEC dbo.SP_Transaction_CompleteTransaction @Id, @WasDelivered, @WasPaid, @NumError OUTPUT, @Result OUTPUT";
                var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<RespuestaDB> GetTransactionStatus(Guid idTransaction)
        {
            try
            {
                var NumError = new SqlParameter
                {
                    ParameterName = "NumError",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                var Result = new SqlParameter
                {
                    ParameterName = "Result",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Direction = ParameterDirection.Output
                };

                SqlParameter[] parameters =
                {
                new SqlParameter("IdTransaction", idTransaction),
                NumError,
                Result
            };
                string sqlQuery = "EXEC dbo.SP_Transaction_GetStatus @IdTransaction, @NumError OUTPUT, @Result OUTPUT";
                var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}
