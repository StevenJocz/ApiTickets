using Domain.Utilidades;
using Infrastructure.Seguridad;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Persistence.Commands;
using Persistence.Queries;
using System.Text;

namespace EducacionContinua.Application
{
    public static class StartupSetup
    {
        public static IServiceCollection AddStartupSetup(this IServiceCollection service, IConfiguration configuration)
        {
            // Queries 
            service.AddTransient<ICatalogoQueries, CatalogoQueries>();
            service.AddTransient<IUsuarioQueries, UsuarioQueries>();
            service.AddTransient<ITicketQueries, TicketQueries>();

            //Commands
            service.AddTransient<ITicketCommands, TicketCommands>();


            // Utilidades
            service.AddScoped<IPassword, Password>();
            

            // Servicios
            service.AddScoped<IGenerarToken, GenerarToken>();

            // Autenticacion jwt
            var key = configuration.GetValue<string>("Jwt:key");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            service.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            return service;
        }
    }
}
