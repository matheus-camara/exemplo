using Api.Configuration;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependancyInjection(builder.Configuration);

builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

builder.Services.AddControllers(Filters.AddFilters).AddJsonConfiguration();

builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" }); });

ValidatorOptions.Global.LanguageManager.Enabled = false;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.AddSwagger();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseForwardedHeaders();

app.MapControllers();
app.UseCors(config =>
    config
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin()
        .Build());

app.UseMigrations();

app.Run();

public partial class Program
{
}