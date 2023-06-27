using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using WebApiApp.Configuration;
using WebApiApp.Context;
using WebApiApp.Repository;
using WebApiApp.Service;

namespace WebApiApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            string conn = builder.Configuration.GetConnectionString("AppConn");
            builder.Services.AddDbContext<AppDbContext>(u=>u.UseSqlServer(conn));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IHotelRepository,HotelRepository> ();
            builder.Services.AddScoped<IHotelService,HotelService> ();
            builder.Services.AddAutoMapper(typeof(MapperConig));
            builder.Services.AddHealthChecks().AddSqlServer(conn);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.MapHealthChecks("/health");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
           
            app.Run();
        }
    }
}