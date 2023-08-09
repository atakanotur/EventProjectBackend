using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Core.Extensions;
using Core.Utilities.Security.Jwt;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // IOC Container Autofac
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());
            });


            var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });


            builder.Services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule()
            });

            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder
                   .WithOrigins(
                    "http://10.0.2.2:8081",
                    "https://10.0.2.2:8081",
                    "https://10.0.2.2:8081",
                    "http://10.0.2.2:3000",
                    "http://10.0.2.2:7204",
                    "https://10.0.2.2:7204",
                    "https://localhost:5554",
                    "http://localhost:5554",
                    "https://localhost:7204",
                    "http://localhost:7204",
                    "https://localhost:8081",
                    "https://localhost:8080",
                    "https://192.168.1.101:5554",
                    "http://192.168.1.101:5554",
                    "http://192.168.1.101:8081",
                    "https://127.0.0.1:7204",
                    "https://127.0.0.1:8080",
                    "https://127.0.0.1:8081",
                    "https://95.70.132.121:7204",
                    "https://95.70.132.121:8081",
                    "https://95.70.132.121:8080"
                    )
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    );
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors(builder => builder
             .WithOrigins(
                    "http://10.0.2.2:8081",
                    "https://10.0.2.2:8081",
                    "https://10.0.2.2:8081",
                    "http://10.0.2.2:3000",
                    "http://10.0.2.2:7204",
                    "https://10.0.2.2:7204",
                    "https://localhost:5554",
                    "http://localhost:5554",
                    "https://localhost:7204",
                    "http://localhost:7204",
                    "https://localhost:8081",
                    "https://localhost:8080",
                    "https://192.168.1.101:5554",
                    "http://192.168.1.101:5554",
                    "http://192.168.1.101:8081",
                    "https://127.0.0.1:7204",
                    "https://127.0.0.1:8080",
                    "https://127.0.0.1:8081",
                    "https://95.70.132.121:7204",
                    "https://95.70.132.121:8081",
                    "https://95.70.132.121:8080"
                    )
            .AllowAnyHeader()
            .AllowCredentials()
            .AllowAnyMethod());

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