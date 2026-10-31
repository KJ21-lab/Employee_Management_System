using EmployeeManagementSystem.Server.Models.Interfaces;

using EmployeeMangementSystem.Server;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.IdentityModel.Tokens;

using SQLitePCL;

using System.Data.Common;
using System.Text;

Batteries.Init();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the SQLite provider factory once at startup.
DbProviderFactories.RegisterFactory("Microsoft.Data.Sqlite", SqliteFactory.Instance);


// Register all dependenciy injections
builder.Services.AddAllDependencies();

builder.Services.AddSingleton<IPasswordHasher<IAccountRecord>, PasswordHasher<IAccountRecord>>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options => {
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder => {
                          builder.WithOrigins("https://localhost:50571")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];

if (string.IsNullOrWhiteSpace(secretKey)) 
   throw new InvalidOperationException("JWT SecretKey is missing or empty in configuration.");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
       options.TokenValidationParameters = new TokenValidationParameters {
          ValidateIssuer = false,   
          ValidateAudience = false,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
          ClockSkew = TimeSpan.Zero 
       };
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

app.UseAuthentication();
app.UseAuthorization();
app.UseExceptionHandler(exceptionApp => {
   exceptionApp.Run(async context =>
   {
      context.Response.StatusCode = StatusCodes.Status500InternalServerError;
      context.Response.ContentType = "application/json";

      var errorResponse = new {
         Message = "An unexpected internal server error occurred."
      };

      await context.Response.WriteAsJsonAsync(errorResponse);
   });
});
app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
