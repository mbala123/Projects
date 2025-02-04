using FileLibrary.Repositories;
using Microsoft.AspNetCore.Authentication.Negotiate;

namespace FileManagementWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IFileManager,FileManagerRepository>();
            builder.Services.AddScoped<IAccount,AccountRepository>();
            builder.Services.AddScoped<ICategory, CategoryRepository>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
          //  app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}
