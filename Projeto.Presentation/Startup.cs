using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Projeto.CrossCutting.Mail;
using Projeto.Domain.Contracts.CrossCutting;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Services;
using Projeto.Infra.Data.Contexts;
using Projeto.Infra.Data.Repositories;

namespace Projeto.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region Swagger

            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Sistema de Controle de Clientes",
                    Description = "Projeto desenvolvido em DDD com API e EntityFramework",
                    Version = "v1",
                   
                });
            });

            #endregion

            #region Injeção de dependencia

            services.AddTransient<IClienteDomainService, ClienteDomainService>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IEmailMessage, EmailMessage>();
            services.AddTransient<IDependenteDomainService, DependenteDomainService>();
            services.AddTransient<IDependenteRepository, DependenteRepository>();


            #endregion

            #region EntityFramework

            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Projeto")));

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c=> 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto API");
            });
            #endregion

            app.UseMvc();
        }
    }
}
