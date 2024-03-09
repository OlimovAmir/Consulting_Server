
using Consulting_Server.Infrastructure;
using Consulting_Server.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Text.Json.Serialization;

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

            builder.Services.AddControllers()
           .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000") // Разрешение запроса от фронтенд домен
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            builder.Services.AddScoped<IMessageFromUserService, MessageFromUserService>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<MemoryContext>();
                context.Database.Migrate();



            }
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
