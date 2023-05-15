using Levva.Newbies.Coins.Data;
using Levva.Newbies.Coins.Data.Interfaces;
using Levva.Newbies.Coins.Data.Repositories;
using Levva.Newbies.Coins.Logic.Interfaces;
using Levva.Newbies.Coins.Logic.MapperProfiles;
using Levva.Newbies.Coins.Logic.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Levva.Newbies.Coins;

public class Program 
{ 
    public static void Main(string[] args) 
    {
        var builder = WebApplication.CreateBuilder(args);
              
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        //configura autenticação essencial para todos os endpoints para melhorar a segurança
        builder.Services.AddMvc(config =>
        {
            var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();
            config.Filters.Add(new AuthorizeFilter(policy));
        });

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }
        ).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(builder.Configuration.GetSection("Secret").Value)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        builder.Services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "API LevvaCoins", Version = "v1" });
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
                              "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n" +
                              "Exemplo (informar sem as aspas): 'Bearer 12345abcdef'",

                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
            });
            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
        });

        builder.Services.AddDbContext<Context>(options => options.UseSqlite(builder.Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("Levva.Newbies.Coins")));
        builder.Services.AddAutoMapper(typeof(DefaultMapper));

        builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();
        builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

        builder.Services.AddScoped<IUsuarioService, UsuarioService>();
        builder.Services.AddScoped<ITransacaoService, TransacaoService>();
        builder.Services.AddScoped<ICategoriaService, CategoriaService>();      

        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        var cultureInfo = new CultureInfo("pt-BR");
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

        app.Run();
    }
}


