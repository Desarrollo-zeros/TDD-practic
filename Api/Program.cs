using Domain.Contract;
using Infrastructure;
using Infrastructure.Repositories;
using Infrastructure.UniOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//se añade siempre todo los contenedores de nuestra logica
//clases que se instancian como inyecciones de dependencias
//


builder.Services.AddDbContext<IAppDbContext, AppDbContext>(
    options => 
    options.UseMySql(
            builder.Configuration.GetConnectionString("DefaultConnection"), 
            new MySqlServerVersion(new Version(8, 0, 30)),
             b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
));

builder.Services.AddScoped<IAppDbContext, AppDbContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<AppDbContext>();
    if (dbContext.Database.CanConnect())
    {
        var pendenting = dbContext.Database.GetPendingMigrations().ToList();
        if (pendenting.Any())
        {
            dbContext.Database.Migrate();
        }
    }
    else
    {
        dbContext.Database.EnsureCreated();
        dbContext.Database.Migrate();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
