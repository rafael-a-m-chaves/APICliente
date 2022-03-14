using APICliente.Application.IServices;
using APICliente.Application.Services;
using APICliente.Infra.Contexts;
using APICliente.Infra.IRepositories;
using APICliente.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICliente
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
            //Obtem a string de conexão com o banco de dados
            var connection = Configuration["ConnectionStrings:DefaultConection"];
            //Adiciona o Context e determina o tipo de banco de dados e passa a string de conexão
            services.AddDbContext<Context>(options => options.UseSqlServer(connection));

            //Mapeamento dos services e Repositores
            #region Services
            services.AddTransient<IVendasClienteService, VendasClienteService>();
            services.AddTransient<IUsuarioServices, UsuarioService>();
            #endregion

            #region Repository
            services.AddTransient<IVendasClienteRepository, VendasClienteRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            #endregion

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
