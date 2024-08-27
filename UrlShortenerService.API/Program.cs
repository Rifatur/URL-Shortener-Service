using Microsoft.EntityFrameworkCore;
using UrlShortenerService.Application;
using UrlShortenerService.Core.Interfaces;
using UrlShortenerService.Infrastructure.Context;
using UrlShortenerService.Infrastructure.Repositories;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<UrlShortenerDbContext>(options =>
    options.UseInMemoryDatabase("UrlShortenerDb"));

builder.Services.AddScoped<IUrlRepository, UrlRepository>();
builder.Services.AddApplication();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
