using CE.Chepeat.Application.Controllers;
using CE.Chepeat.Application.Mapping;
using CE.Chepeat.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Application
{
    public static class DContainer
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IApiController, ApiController>();
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            //Add new aggregates
            services.AddScoped<IJwtService, JwtService>();

            return services;
        }
    }
}
