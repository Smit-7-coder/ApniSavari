using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ApniSavari.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using ApniSavari.Application.Interfaces;
using ApniSavari.Infrastructure.Services;
using ApniSavari.Infrastructure.Persistence.Context.Persistence.Entities;

namespace ApniSavari.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Authentication Service
        builder.Services.AddScoped<IAuthService, AuthService>();

        builder.Services.AddScoped<IAuthService, AuthService>();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AngularClient", policy =>
            {
                policy
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        // JWT Authentication
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],

                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            builder.Configuration["Jwt:Key"]!))
                };
            });

        // Authorization
        builder.Services.AddAuthorization();

        // Database
        builder.Services.AddDbContext<ApniSavariDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));

        // Controllers
        builder.Services.AddControllers();

        

        var app = builder.Build();

        // HTTP Request Pipeline
        if (app.Environment.IsDevelopment())
        {
            
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("AngularClient");

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}