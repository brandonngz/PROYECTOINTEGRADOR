using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;//PARA PODER USAR UseSqlServer
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProyectoIntegrador.Models;//Referencia para poder usa la clase ProyectoIntegradorContext. [Conexion SQL]

namespace ProyectoIntegrador
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
        {   //                            Establecemos las propiedades del MIddleward

            services.AddSession(optiones =>
            {
                optiones.IdleTimeout = TimeSpan.FromSeconds(300);
                optiones.Cookie.HttpOnly = true;
            });
            services.AddControllersWithViews();
            
            //Agregar un metodo para establecer la conexion con nuestra BD SQL
            // 🡻                  🡻tipo de contexto         🡻Parametro con los datos de la clase en ProyectoIntegradorContext.
            // 🡻                                                     🡻Operador Lambda, define a opciones como parametro
            //                                                                                  🡻Objeto Configuration acceder al archivo .json metodo 
            //                                                                                  🡻GetConnectionString obtenemos la propiedad ProyectoIntegradorContext el archivo appsettings.json                       
            services.AddDbContext<ProyectoIntegradorContext>(opciones => opciones.UseSqlServer(Configuration.GetConnectionString("ProyectoIntegradorContext")));

              
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
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
