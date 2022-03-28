using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TargetInvestimento.Application.Interfaces;
using TargetInvestimento.Application.Services;
using TargetInvestimento.Domain.Interfaces.Repositories;
using TargetInvestimento.Domain.Interfaces.Repositorys;
using TargetInvestimento.Domain.Services;
using TargetInvestimento.Infra.Repository;
using TargetInvestimento.Presentation.Configurations;

namespace TargetInvestimentos.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            SwaggerConfiguration.ConfigureServices(services); //SWAGGER
            CorsConfiguration.ConfigureServices(services); //CORS

            services.AddControllers();
            var connectionString = Configuration.GetConnectionString("Conexao");

            services.AddTransient<IClienteRepository, ClienteRepository>
                (map => new ClienteRepository(connectionString));

            services.AddTransient<IClienteApplicationService, ClienteApplicationService>();
            services.AddTransient<IClienteDomainService, ClienteDomainService>();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            SwaggerConfiguration.Configure(app);
            CorsConfiguration.Configure(app);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
