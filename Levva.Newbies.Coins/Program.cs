using Levva.Newbies.Coins.Data;
using Levva.Newbies.Coins.Data.Interfaces;
using Levva.Newbies.Coins.Data.Repositories;
using Levva.Newbies.Coins.Logic.MapperProfiles;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Levva.Newbies.Coins;

public class Program 
{ 
    public static void Main(string[] args) 
    {
        var builder = WebApplication.CreateBuilder(args);
              
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<Context>(options => options.UseSqlite(builder.Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("Levva.Newbies.Coins")));
        builder.Services.AddAutoMapper(typeof(DefaultMapper));

        builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();


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

        var cultureInfo = new CultureInfo("pt-BR");
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

        app.Run();
    }
}


