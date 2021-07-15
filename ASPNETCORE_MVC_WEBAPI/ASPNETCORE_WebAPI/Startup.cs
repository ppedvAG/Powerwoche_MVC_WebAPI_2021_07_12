using ASPNETCORE_WebAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;




namespace ASPNETCORE_WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        {
            //Konfigurationen aus AppSettings werden eingelesen und verf�gbar (via IOC Container) gemacht
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Web API Funktionaltit�t - Ben�tigt das Verzeichnis Controllers
            /* services.AddControllers(); *///Endpoint: endpoints.MapControllers();

            services.AddControllers(options =>
            {
                options.InputFormatters.Insert(0, GetJsonPatchInputFormatter());

                //Beispiel Browser und Inhaltsaushandlung
                //options.RespectBrowserAcceptHeader = true; // false by default




            })
                .AddXmlSerializerFormatters() //Hinzuf�gen von Unterst�tzung f�r das XML-Format
                .AddJsonOptions(options => //Konfigurieren System.Text.Json von basierten Formatierern
                    options.JsonSerializerOptions.PropertyNamingPolicy = null); //Die Standardformatierung ist camelCase. Der folgende hervorgehobene Code legt die PascalCase-Formatierung fest:


            // Swagger UI - zum Testen der WebAPI Methoden
            services.AddSwaggerGen(c =>
            {
                //Es k�nnen mehrere Versionen sogar dargestellt werden
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ASPNETCORE_WebAPI", Version = "v1" });
                //c.SwaggerDoc("v2", new OpenApiInfo { Title = "ASPNETCORE_WebAPI", Version = "v2" });
            });


            services.AddDbContext<MovieDbContext>(options =>
            {
                options.UseInMemoryDatabase("MovieDB");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASPNETCORE_WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }



        private static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
        {
            var builder = new ServiceCollection()
                .AddLogging()
                .AddMvc()
                .AddNewtonsoftJson()
                .Services.BuildServiceProvider();

            return builder
                .GetRequiredService<IOptions<MvcOptions>>()
                .Value
                .InputFormatters
                .OfType<NewtonsoftJsonPatchInputFormatter>()
                .First();
        }
    }
}
