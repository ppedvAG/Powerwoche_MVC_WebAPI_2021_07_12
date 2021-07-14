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
using Westwind.AspNetCore.LiveReload;
using Microsoft.EntityFrameworkCore;
using ASPNETCOREMVC.Data;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using ASPNETCOREMVC.Middleware;

namespace ASPNETCOREMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration) //IConfiguration repr�sentiert die AppSetting.json im Arbeitsspeicher
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; } //AppSetting ist im Arbeitspeicher geladen

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) //Inversion of Control
        {
            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            services.AddRazorPages();

            //MVC wird hier zum ASP.NET Core Projekt hinzugef�gt
            //Wenn wir AddController with View verwenden -> ben�tigt das Programm folgende Ordner:
            //Views Verzeichnis
            //Controllers Verzeichnis
            //Models Verzeichnis

            //Wir binden jetzt unsere Car-Library in unser MVC Project hinzu (funktioniert auch in WebAPI und RazorPages)
            services.AddSingleton<IMockCar, MockCar>(); //Wann nimmt man Singleton -> Bei gro�en Objekten mit langer Initialisierungszeit 
            
            
            //services.AddTransient<ICar, Car>(); //Request bezogene Techniken
            //services.AddScoped<ICar, Car>(); //Request bezogene Techniken


            //services.AddRazorPages();           // Razor Page Logik wird hier hinzugef�gt. -> Es wird ein Page Verzeichnis ben�tigt

            //services.AddControllers();           //WebAPI ben�tigt nur ein Controller-Verzeichnis


            //services.AddMvc(); //Intern wird .AddControllersWithViews() + .AddRazorPages();      


            services.Configure<SampleWebSettings>(Configuration);

            services.AddLiveReload();

            services.AddDbContext<MovieDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MovieDbContext")));

            services.AddSession();
            services.AddAuthentication();

            services.AddLocalization();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                 {
                    new CultureInfo("en"),
                    new CultureInfo("de"),
                    new CultureInfo("fr"),
                    //new CultureInfo("es"),
                    //new CultureInfo("ru"),
                    //new CultureInfo("ja"),
                    //new CultureInfo("ar"),
                    //new CultureInfo("zh"),
                    //new CultureInfo("en-GB")
                };
                options.DefaultRequestCulture = new RequestCulture("de");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment()) //F�r Entwickler 
            {
                app.UseDeveloperExceptionPage(); //Detailierte Fehlermeldungausgabe f�r Entwickler
                app.UseLiveReload();
            }
            else
            {
                //Wenn Webseite produktiv eingesetzt wird (
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Allgemeine Konfiguration
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            
           

            AppDomain.CurrentDomain.SetData("BildVerzeichnis", env.WebRootPath);


            #region CustomizeMiddleware
            #region Sample1
            //Use verwendet next() und verkettete somit. 
            //app.Use(async (context, next) =>
            //{
            //    //Request Part
            //    //await context.Response.WriteAsync("Vor Invoke from 1st app.Use()\n");
            //    await next();
            //    //Response Part
            //    //await context.Response.WriteAsync("Nach Invoke from 1st app.Use()\n");
            //});

            //app.Use(async (context, next) =>
            //{
            //    //Request Part
            //    //await context.Response.WriteAsync("Vor Invoke from 2nd app.Use()\n");
            //    await next();
            //    //Response Part
            //    //await context.Response.WriteAsync("Nach Invoke from 2nd app.Use()\n");
            //});
            #endregion




            #region Sample 2
            //Request                         Response
            //https://localhost:5001/        Hello from app.Run()
            //https://localhost:5001/m1      Hello from 1st app.Map()
            //https://localhost:5001/m1/xyz  Hello from 1st app.Map()
            //https://localhost:5001/m2      Hello from 2nd app.Map()
            //https://localhost:5001/m500    Hello from app.Run()
            app.Map("/m1", HandleMapOne);
            app.Map("/m2", appMap =>
            {
                appMap.Run(async context =>
                {
                    await context.Response.WriteAsync("Hello from 2nd app.Map()");
                });
            });
            #endregion

            #region Tumbnail Middleware
            app.MapWhen(context => context.Request.Path.ToString().Contains("imagegen"), subapp =>
            {
                subapp.UseThumbnailGen();
            });

            #endregion

            #endregion
            // Wenn wir AddControllersWithViews verwenden, ben�tigen wir f�r MVC Request folgenden Endpoint. 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "movie",
                    pattern: "movie/{*movie}", defaults: new { controller = "Movie", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


                endpoints.MapRazorPages();
            });
        }



        private static void HandleMapOne(IApplicationBuilder app)
        {
            //Run Terminiert eine Middleware- Das Request wird nicht mehr weitergereicht 
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from 1st app.Map");
            });
        }
    }
}
