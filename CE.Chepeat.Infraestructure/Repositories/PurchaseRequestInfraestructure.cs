using CE.Chepeat.Domain.Aggregates.PurchaseRequest;
using CE.Chepeat.Domain.DTOs;
using CE.Chepeat.Domain.DTOs.PurchaseRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Developer : Hector Nuñez Cruz
/// Creation Date : 23/10/2024
/// Creation Description:Repositorie de Solicitud
/// Update Date : 23/10/2024
/// Update Description : --
/// CopyRight: Chepeat

namespace CE.Chepeat.Infraestructure.Repositories
{
    public class PurchaseRequestInfraestructure : IPurchaseRequestInfraestructure
    {
        private readonly ChepeatContext _context;

        public PurchaseRequestInfraestructure(ChepeatContext context)
        {
            _context = context;
        }

        public async Task<PurchaseRequestDto> GetRequestById(Guid id)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("Id", id)
                };

                string sqlQuery = "EXEC dbo.SP_PurchaseRequests_ViewById @Id";
                var dataSP = await _context.purchaseRequestDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<List<PurchaseRequestDto>> GetRequestsByProduct(Guid id)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("IdProduct", id)
                };

                string sqlQuery = "EXEC dbo.SP_PurchaseRequests_ViewByProduct @IdProduct";
                var dataSP = await _context.purchaseRequestDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP;
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<RespuestaDB> CreatePurchaseRequest(PurchaseRequestAggregate request)
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
                new SqlParameter("IdProduct", request.IdProduct),
                new SqlParameter("IdBuyer", request.IdBuyer),
                NumError,
                Result
            };

                string sqlQuery = "EXEC dbo.SP_PurchaseRequest_Create @IdProduct, @IdBuyer, @NumError OUTPUT, @Result OUTPUT";
                var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<List<PurchaseRequestDto>> GetRequestsBySeller(Guid idSeller)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("IdSeller", idSeller)
                };

                string sqlQuery = "EXEC dbo.SP_PurchaseRequests_ViewBySeller @IdSeller";
                var dataSP = await _context.purchaseRequestDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP;
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<List<PurchaseRequestDto>> GetRequestsByBuyer(Guid idBuyer)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("IdBuyer", idBuyer)
                };

                string sqlQuery = "EXEC dbo.SP_PurchaseRequests_ViewByBuyer @IdBuyer";
                var dataSP = await _context.purchaseRequestDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP;
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<RespuestaDB> RejectRequest(Guid idRequest)
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
                    new SqlParameter("IdRequest", idRequest),
                    NumError,
                    Result
            };

                string sqlQuery = "EXEC dbo.SP_PurchaseRequest_Reject @IdRequest, @NumError OUTPUT, @Result OUTPUT";
                var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<RespuestaDB> CancelRequest(Guid idRequest)
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
            new SqlParameter("IdRequest", idRequest),
            NumError,
            Result
        };

                string sqlQuery = "EXEC dbo.SP_PurchaseRequest_Cancel @IdRequest, @NumError OUTPUT, @Result OUTPUT";
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