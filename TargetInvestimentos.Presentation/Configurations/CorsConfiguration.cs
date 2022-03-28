using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetInvestimento.Presentation.Configurations
{
    public class CorsConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(
                   s => s.AddPolicy("DefaultPolicy", builder =>
                   {
                       builder.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                   })
               );
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseCors("DefaultPolicy");
        }
    }
}
