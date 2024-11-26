

using CE.Chepeat.Domain.Aggregates.Product;
using CE.Chepeat.Domain.DTOs.Product;

namespace CE.Chepeat.Infraestructure.Repositories;
public class ProductInfraestructure : IProductInfraestructure
{
    private readonly ChepeatContext _context;

    public ProductInfraestructure(ChepeatContext context)
    {
        _context = context;
    }

    public async Task<RespuestaDB> AddProduct(ProductRequest request)
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
                new SqlParameter("Name", request.Name),
                new SqlParameter("Description", request.Description),
                new SqlParameter("Price", request.Price),
                new SqlParameter("Stock", request.Stock),
                new SqlParameter("Measure", request.Measure),
                new SqlParameter("ImagenUrl", request.ImagenUrl),
                new SqlParameter("IdSeller", request.IdSeller),
                NumError,
                Result
            };
            string sqlQuery = "EXEC dbo.SP_Products_Insert @Name, @Description, @Price, @Stock, @Measure, @ImagenUrl, @IdSeller, @NumError OUTPUT, @Result OUTPUT";
            var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            return dataSP.FirstOrDefault();
        }
        catch (SqlException ex)
        {
            throw;
        }
    }

    public async Task<RespuestaDB> DeleteProduct(Guid id)
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
            string sqlQuery = "EXEC dbo.SP_Products_Delete @Id, @NumError OUTPUT, @Result OUTPUT";
            var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            return dataSP.FirstOrDefault();
        }
        catch (SqlException ex)
        {
            throw;
        }
    }

    public async Task<Product> GetProductById(Guid id)
    {
        try
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("Id", id)
            };
            string sqlQuery = "EXEC dbo.sp_select_product_by_id @Id";
            var dataSP = await _context.Products.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            return dataSP.FirstOrDefault();
        }
        catch (SqlException ex)
        {
            throw;
        }
    }

    public async Task<List<Product>> GetProducts()
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
            SqlParameter[] parameters = { NumError, Result };
            string sqlQuery = "EXEC dbo.SP_Products_Selection @NumError OUTPUT, @Result OUTPUT";
            var dataSP = await _context.Products.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            return dataSP;
        }
        catch (SqlException ex)
        {
            throw;
        }
    }

    public async Task<List<Product>> GetProductsByIdSeller(Guid id)
    {
        try
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("IdSeller", id)
            };
            string sqlQuery = "EXEC dbo.sp_select_products_by_idSeller @IdSeller";
            return await _context.Products.FromSqlRaw(sqlQuery, parameters).ToListAsync();
        }
        catch (SqlException ex)
        {
            throw;
        }
    }

    public async Task<List<Product>> GetProductsByRadius(ProductRadiusRequest request)
    {
        try
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("Latitude", request.Latitude),
                new SqlParameter("Longitude", request.Longitude),
                new SqlParameter("RadiusKm", request.RadiusKm)
            };
            string sqlQuery = "EXEC dbo.sp_select_products_by_radius @Latitude, @Longitude, @RadiusKm";
            var dataSP = await _context.Products.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            return dataSP;
        }
        catch (SqlException ex)
        {
            throw;
        }
    }

    public async Task<RespuestaDB> UpdateProduct(ProductRequest request)
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
                new SqlParameter("Name", request.Name),
                new SqlParameter("Description", request.Description),
                new SqlParameter("Price", request.Price),
                new SqlParameter("Stock", request.Stock),
                new SqlParameter("Measure", request.Measure),
                new SqlParameter("ImagenUrl", request.ImagenUrl),
                NumError,
                Result
            };
            string sqlQuery = "EXEC dbo.SP_Products_Update @Id, @Name, @Description, @Price, @Stock, @Measure, @ImagenUrl, @NumError OUTPUT, @Result OUTPUT";
            var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            return dataSP.FirstOrDefault();
        }
        catch (SqlException ex)
        {
            throw;
        }
    }
}
