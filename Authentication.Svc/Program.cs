using Authentication.Svc.GrantTypes;
using Authentication.Svc.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Authentication.Svc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IGrantValidatorService, GrantValidatorService>();
            builder.Services.AddScoped<ITokenGenerationService, TokenGenerationService>();

            //Register Grant Types
            builder.Services.AddScoped<PasswordGrantType>();
            builder.Services.AddScoped<RefreshTokenGrantType>();

            builder.Services.AddControllers();
  

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
