using ASPNETCOREMVC.Models;
using DependencyInversionSample;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration) //IConfiguration repräsentiert die AppSetting.json im Arbeitsspeicher
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; } //AppSetting ist im Arbeitspeicher geladen

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) //Inversion of Control
        {
            services.AddControllersWithViews(); //MVC wird hier zum ASP.NET Core Projekt hinzugefügt
                                                //Wenn wir AddController with View verwenden -> benötigt das Programm folgende Ordner:
                                                //Views Verzeichnis
                                                //Controllers Verzeichnis
                                                //Models Verzeichnis

            //Wir binden jetzt unsere Car-Library in unser MVC Project hinzu (funktioniert auch in WebAPI und RazorPages)
            services.AddSingleton<IMockCar, MockCar>(); //Wann nimmt man Singleton -> Bei großen Objekten mit langer Initialisierungszeit 
            
            
            services.AddTransient<ICar, Car>(); //Request bezogene Techniken
            //services.AddScoped<ICar, Car>(); //Request bezogene Techniken


            //services.AddRazorPages();           // Razor Page Logik wird hier hinzugefügt. -> Es wird ein Page Verzeichnis benötigt

            //services.AddControllers();           //WebAPI benötigt nur ein Controller-Verzeichnis


            //services.AddMvc(); //Intern wird .AddControllersWithViews() + .AddRazorPages();      


            services.Configure<SampleWebSettings>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) //Für Entwickler 
            {
                app.UseDeveloperExceptionPage(); //Detailierte Fehlermeldungausgabe für Entwickler
            }
            else
            {
                //Wenn Webseite produktiv eingesetzt wird (
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
