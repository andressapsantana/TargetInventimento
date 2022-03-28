using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetInvestimento.Presentation.Configurations
{
    public class SwaggerConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API para consulta de novos clientes - Target Bank.",
                    Description = "Projeto Target Bank Investimentos",
                    Contact = new OpenApiContact
                    {
                        Name = "Target Bank",
                        Url = new Uri("https://targetbank.com.br/"),
                        Email = "contato@targetbank.com.br"
                    }
                });
            });
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoAPITargetBank");
            });
        }
    }
}
