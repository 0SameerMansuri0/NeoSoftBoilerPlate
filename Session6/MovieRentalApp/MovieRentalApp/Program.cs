using AutoMapper;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieRentalApp.Configuration;
using MovieRentalApp.Context;
using MovieRentalApp.Healthckecks;
using MovieRentalApp.Models;
using MovieRentalApp.Repository.MovieModule;
using MovieRentalApp.Service.MovieModule;
using System.Net;

namespace MovieRentalApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
/*
            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                serverOptions.Listen(IPAddress.Any, 5000); // Specify your desired port number
            });*/

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            string conn = builder.Configuration.GetConnectionString("AppConn");
            builder.Services.AddDbContext<AppDbContext>(u => u.UseSqlServer(conn));
            //builder.Services.AddAutoMapper(typeof(MapConfig));
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddIdentity<User, IdentityRole>()
                            .AddEntityFrameworkStores<AppDbContext>();
                 builder.Services.AddSession();

            builder.Services.AddHealthChecks().AddSqlServer(conn).AddCheck<GetAllHeathCheck>("GetAllMovies");
                
               
            builder.Services.AddHealthChecksUI().AddInMemoryStorage();

            // builder.Services.AddScoped<UserManager<User>>();
            //builder.Services.AddScoped<SignInManager<User>>();
            builder.Services.AddMemoryCache();


            builder.Services.AddScoped<IMovieService, MovieService>();
           
            var app = builder.Build();
           
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecksUI();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHealthChecks("/healthchecks", new HealthCheckOptions
                {
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                endpoints.MapHealthChecks("/booking/index", new HealthCheckOptions
                {
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });
          
           
            

            app.Run();
        }
    }
}