using Core;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SixLabors.ImageSharp;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//var Configuration = builder.Configuration;
//AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
//builder.Services.AddDbContext<DataBaseContext>(options =>
//        options.UseNpgsql(Configuration.GetConnectionString("NostalgiaPostgresConnection")));

string connection = builder.Configuration.GetConnectionString("NostalgiaSQLContextConnection") ?? throw new InvalidOperationException("Connection string 'ShopMVCConnection' not found.");
builder.Services.AddDbContext(connection);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepository();
builder.Services.AddAutoMapper();
builder.Services.AddCustomServices();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
