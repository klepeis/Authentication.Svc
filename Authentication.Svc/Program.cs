using Authentication.Svc.Framework.ExceptionHandlers;
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

            builder.Services.AddHttpContextAccessor();

            // Add services to the container.
            builder.Services.AddScoped<IGrantValidatorService, GrantValidatorService>();
            builder.Services.AddScoped<ITokenGenerationService, TokenGenerationService>();

            //Register Grant Types
            builder.Services.AddScoped<PasswordGrantType>();
            builder.Services.AddScoped<RefreshTokenGrantType>();

            //Register Exception Handlers
            builder.Services.AddProblemDetails();  //TODO: Need to see what this does. This is required to use the Global Exception handler.
            builder.Services.AddExceptionHandler<InvalidClientIdExceptionHandler>();
            builder.Services.AddExceptionHandler<InvalidGrantTypeExceptionHandler>();
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>(); //Review underlying code. Setup for this was taken from https://medium.com/@AntonAntonov88/handling-errors-with-iexceptionhandler-in-asp-net-core-8-0-48c71654cc2e

            builder.Services.AddControllers();
  

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
            }

            app.UseExceptionHandler();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
