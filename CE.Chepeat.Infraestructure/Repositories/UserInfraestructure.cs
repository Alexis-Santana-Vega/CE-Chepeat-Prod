using CE.Chepeat.Domain.Aggregates.User;

namespace CE.Chepeat.Infraestructure.Repositories;
public class UserInfraestructure : IUserInfraestructure
{
    private readonly ChepeatContext _context;

    public UserInfraestructure(ChepeatContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Consulta todos los registros de la tabla Users
    /// </summary>
    /// <returns></returns>
    public async Task<List<UserDto>> GetUsers()
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
                NumError,
                Result
            };
            string sqlQuery = "EXEC dbo.SP_Users_Selection @NumError OUTPUT, @Result OUTPUT";
            var dataSP = await _context.userDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            return dataSP;
        }
        catch (SqlException ex)
        {
            throw;
        }
    }

    /// <summary>
    /// Agrega un registro de la tabla GI_Persona
    /// </summary>
    /// <returns></returns>
    public async Task<RespuestaDB> AddUser(UserAggregate userAggregate)
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
                new SqlParameter("Email",userAggregate.Email),
                new SqlParameter("Fullname", userAggregate.Fullname),
                NumError,
                Result
            };
            string sqlQuery = "EXEC dbo.sp_user_add  @Email, @Password, @Fullname, @NumError OUTPUT, @Result OUTPUT";
            var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            return dataSP.FirstOrDefault();
        }
        catch(SqlException ex)
        {
            throw;
        }
    }

    /// <summary>
    /// Consulta todos los registros de la tabla Users
    /// </summary>
    /// <returns></returns>
    public async Task<RespuestaDB> DeleteUser(Guid id)
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
            string sqlQuery = "EXEC dbo.SP_User_Delete @Id, @NumError OUTPUT, @Result OUTPUT";
            var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            return dataSP.FirstOrDefault();
        }
        catch (SqlException ex)
        {
            throw;
        }
    }

    /// <summary>
    /// Agrega un registro de la tabla GI_Persona
    /// </summary>
    /// <returns></returns>
    public async Task<RespuestaDB> UpdateUser(UserAggregate userAggregate)
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
                new SqlParameter("Id", userAggregate.Id),
                new SqlParameter("Email",userAggregate.Email),
                new SqlParameter("Fullname", userAggregate.Fullname),
                NumError,
                Result
            };
            string sqlQuery = "EXEC dbo.sp_user_update @Id, @Email, @Fullname, @NumError OUTPUT, @Result OUTPUT";
            var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            return dataSP.FirstOrDefault();
        }
        catch (SqlException ex)
        {
            throw;
        }
    }

}