using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CE.Chepeat.Infraestructure;
public static class DContainer
{
    public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration)
    {        

        var connectionSettingsSection = configuration.GetSection(ConnectionsSettings.SectionName);
        var connectionSettings = connectionSettingsSection.Get<ConnectionsSettings>();

        services
        .Configure<ConnectionsSettings>(connectionSettingsSection)
        .AddDbContext<ChepeatContext>(options =>
        {
            //options.UseSqlServer(configuration.GetConnectionString("DbConnection"),
            options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"),
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(3600),
                errorNumbersToAdd: null);
                sqlOptions.CommandTimeout(3600);
            });
        });

        services.AddScoped<IAuthInfraestructure, AuthInfraestructure>();
        //Add config cors
        //add config JWT
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options =>
       {
           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = true,
               ValidateAudience = true,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,
               ValidIssuer = configuration["Jwt:Issuer"],
               ValidAudience = configuration["Jwt:Audience"],
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
               ClockSkew = TimeSpan.Zero // Para que el token expire exactamente en el tiempo indicado
           };
       });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("BUYER", policy =>
            {
                policy.RequireClaim("IsBuyer", "True");
            });
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("SELLER", policy =>
            {
                policy.RequireClaim("IsSeller", "True");
            });
        });

        services.AddScoped<IUnitRepository, UnitRepository>();
        return services;
    }
}
