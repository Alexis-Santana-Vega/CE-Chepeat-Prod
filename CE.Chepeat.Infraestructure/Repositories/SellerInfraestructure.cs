using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CE.Chepeat.Domain.Aggregates.Seller;

namespace CE.Chepeat.Infraestructure.Repositories;
public class SellerInfraestructure : ISellerInfraestructure
{
    private readonly ChepeatContext _context;
    public SellerInfraestructure(ChepeatContext context)
    {
        _context = context;
    }

    public async Task<RespuestaDB> DeleteSeller(Guid id)
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
                new SqlParameter("Id", id),
                NumError,
                Result
            };
            string sqlQuery = "EXEC dbo.sp_eliminar_vendedor @Id, @NumError OUTPUT, @Result OUTPUT";
            var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            return dataSP.FirstOrDefault();
        }
        catch (SqlException ex)
        {
            throw;
        }
    }

    public async Task<RespuestaDB> AddSeller(SellerRequest request)
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
                Size = 512,
                Direction = ParameterDirection.Output
            };

            SqlParameter[] parameters =
            {
                new SqlParameter("StoreName", request.StoreName),
                new SqlParameter("Description", request.Description),
                new SqlParameter("Street", request.Street),
                new SqlParameter("ExtNumber", request.ExtNumber),
                new SqlParameter("IntNumber", request.IntNumber),
                new SqlParameter("Neighborhood", request.Neighborhood),
                new SqlParameter("City", request.City),
                new SqlParameter("State", request.State),
                new SqlParameter("CP", request.CP),
                new SqlParameter("AddressNotes", request.AddressNotes),
                new SqlParameter("Latitude", request.Latitude),
                new SqlParameter("Longitude", request.Longitude),
                new SqlParameter("CreatedAt", DateTime.UtcNow),
                new SqlParameter("UpdatedAt", DateTime.UtcNow),
                new SqlParameter("IdUser", request.IdUser),
                NumError,
                Result
            };
            string sqlQuery = "EXEC dbo.sp_registrar_vendedor @StoreName, @Description, @Street, @ExtNumber, @IntNumber, @Neighborhood, @City, @State, @CP, @AddressNotes, @Latitude, @Longitude, @CreatedAt, @UpdatedAt, @IdUser, @NumError OUTPUT, @Result OUTPUT";
            var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            return dataSP.FirstOrDefault();
        }
        catch (SqlException ex)
        {
            throw;
        }
    }

    public async Task<Seller> SelectSellerById(Guid id)
    { 
        try
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("Id", id)
            };
            string sqlQuery = "EXEC dbo.sp_consultar_vendedor_por_id @Id";
            var dataSP = await _context.Sellers.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            var r = dataSP.FirstOrDefault();
            return r;
        }
        catch (SqlException ex)
        {
            throw;
        }
    }

    public async Task<Seller> SelectSellerByIdUser(Guid idUser)
    {
        try
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("IdUser", idUser)
            };
            string sqlQuery = "EXEC dbo.sp_consultar_vendedor_por_idUser @IdUser";
            var dataSP = await _context.Sellers.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            var r = dataSP.FirstOrDefault();
            return r;
        }
        catch (SqlException ex)
        {
            throw;
        }
    }

    public async Task<List<Seller>> SelectSellersByRadius(SellerRadiusRequest request)
    {
        try
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("Latitude", request.Latitude),
                new SqlParameter("Longitude", request.Longitude),
                new SqlParameter("RadiusKm", request.RadiusKm)
            };
            string sqlQuery = "EXEC dbo.sp_consultar_vendedores_por_radio @Latitude, @Longitude, @RadiusKm";
            var dataSP = await _context.Sellers.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            return dataSP;
        }
        catch (SqlException ex)
        {
            throw;
        }
    }

    public async Task<RespuestaDB> UpdateSeller(SellerRequest request)
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
                Size = 512,
                Direction = ParameterDirection.Output
            };

            SqlParameter[] parameters =
            {
                new SqlParameter("Id", request.Id),
                new SqlParameter("StoreName", request.StoreName),
                new SqlParameter("Description", request.Description),
                new SqlParameter("Street", request.Street),
                new SqlParameter("ExtNumber", request.ExtNumber),
                new SqlParameter("IntNumber", request.IntNumber),
                new SqlParameter("Neighborhood", request.Neighborhood),
                new SqlParameter("City", request.City),
                new SqlParameter("State", request.State),
                new SqlParameter("CP", request.CP),
                new SqlParameter("AddressNotes", request.AddressNotes),
                new SqlParameter("Latitude", request.Latitude),
                new SqlParameter("Longitude", request.Longitude),
                new SqlParameter("UpdatedAt", DateTime.UtcNow),
                NumError,
                Result
            };
            string sqlQuery = "EXEC dbo.sp_actualizar_vendedor @Id, @StoreName, @Description, @Street, @ExtNumber, @IntNumber, @Neighborhood, @City, @State, @CP, @AddressNotes, @Latitude, @Longitude, @UpdatedAt, @NumError OUTPUT, @Result OUTPUT";
            var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            return dataSP.FirstOrDefault();
        }
        catch (SqlException ex)
        {
            throw;
        }
    }
}
