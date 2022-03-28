using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TargetInvestimento.Domain.Interfaces.Repositories;
using TargetInvestimento.Application.Interfaces;
using TargetInvestimento.Application.Services;
using TargetInvestimento.Domain.Services;
using TargetInvestimento.Infra.Repository;

namespace TargetInvestimentos.Presentation.Configurations
{ 
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var connectionstring = configuration.GetConnectionString("Conexao");

            services.AddTransient<IClienteApplicationService, ClienteApplicationService>();
            services.AddTransient<IClienteDomainService, ClienteDomainService>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
        }

    }
}
