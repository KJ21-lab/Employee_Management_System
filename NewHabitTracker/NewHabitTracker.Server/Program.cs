using DataAccess.Implementations;
using DataAccess.Interfaces;

using DependencyInjectors;
using DependencyInjectors.BusinessRules;
using DependencyInjectors.PersistenceInjector;

using Microsoft.Data.Sqlite;

using SQLitePCL;

using System.Data.Common;

Batteries.Init();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the SQLite provider factory once at startup.
DbProviderFactories.RegisterFactory("Microsoft.Data.Sqlite", SqliteFactory.Instance);

builder.Services.AddSingleton<DataAcessConfigSettings>();

builder.Services.AddSingleton<IBusinessRulesInjector, BusinessRulesInjector>();

// Register your main DataAccessor to its interface.
builder.Services.AddSingleton<IDataAccessor, DataAccessor>();

// Register the dependency that was missing.
builder.Services.AddSingleton<IPersistenceFactoriesInjector, PersistenceFactoriesInjector>();

// --- END: Corrected Service Registration ---

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options => {
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder => {
                          builder.WithOrigins("https://localhost:50571")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
