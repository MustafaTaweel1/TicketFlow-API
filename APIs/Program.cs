
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.Metrics;
using webAPI.Model;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();
			builder.Services.AddScoped<IAPIs<User>, UserRepository>();
			builder.Services.AddScoped<IAPIs<Password_Reset>, Password_ResetRepository>();
            builder.Services.AddScoped<ITickets<Ticket>, TicketRepository>();


			//         builder.Services.AddDbContext<db>(options =>
			//         {
			//             options.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Create_API; Integrated Security = True;");
			//});

			builder.Services.AddDbContext<db>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyDBContext")));

			var app = builder.Build();

			// Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}