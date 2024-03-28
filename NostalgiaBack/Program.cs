using Core;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NostalgiaBack;
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


builder.Services.AddControllersWithCustomSchema();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGenWithCustomSchema();

builder.Services.AddRepository();

builder.Services.AddAutoMapper();

builder.Services.AddCustomServices();

builder.Services.AddIdentity();

builder.Services.AddCors();

builder.Services.AddAuthenticationWithOptions(builder.Configuration);


var app = builder.Build();

app.UseCors(options =>
    options.AllowAnyHeader()
           .AllowAnyOrigin()
           .AllowAnyMethod());


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseCors("AllowLocalhost5173");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
