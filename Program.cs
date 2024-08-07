
using EnergyApi.Data;
using Microsoft.EntityFrameworkCore;

namespace EnergyApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<TNDbContext>(x =>
                x.UseSqlServer(builder.Configuration["ConnectionStrings:TNDB"])
                .EnableSensitiveDataLogging() // ��� �������
                .LogTo(Console.WriteLine, LogLevel.Information) // ��� �������
            );

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("https://localhost:8050", "http://localhost:8050"));
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.WebHost.UseKestrel((x) =>
                x.ListenAnyIP(8050)
            );

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowSpecificOrigin");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
