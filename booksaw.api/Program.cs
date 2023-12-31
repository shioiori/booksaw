using booksaw.infrastructure;
using booksaw.application;
using MySqlConnector;
using System;
using Microsoft.EntityFrameworkCore;
using booksaw.infrastructure.Data;
using booksaw.api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMySqlDataSource(builder.Configuration.GetConnectionString("BooksawDB"));
builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(builder.Configuration.GetConnectionString("BooksawDB")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddApplication();
builder.Services.AddInfrustructure();

var cors = "cors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(cors,
                      policy =>
                      {
                          policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(cors);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
