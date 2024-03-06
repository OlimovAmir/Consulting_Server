
using Consulting_Server.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Consulting_Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            NpgsqlConnection.GlobalTypeMapper.EnableDynamicJson();

            builder.Services.AddDbContext<MemoryContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DbPostgres"))

                  //.UseLazyLoadingProxies()
            .LogTo(Console.Write, LogLevel.Information)
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            builder.Services.AddLogging(l =>
            {
                //l.ClearProviders();
                //l.AddConsole();
            });
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
