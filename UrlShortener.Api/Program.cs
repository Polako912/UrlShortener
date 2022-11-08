using UrlShortener.Domain.Interfaces.Repositories;
using UrlShortener.Domain.Interfaces.Services;
using UrlShortener.Domain.Profiles;
using UrlShortener.Domain.Services;
using UrlShortener.Infrastructure;
using UrlShortener.Infrastructure.Interfaces;
using UrlShortener.Infrastructure.Repositories;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .WriteTo.Debug()
    .WriteTo.File("logs.txt")
    );

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ShortenedUrlProfile));

builder.Services.AddSingleton<IDbConnectionProvider, DbConnectionProvider>();
builder.Services.AddScoped<IUrlShortenerRepository, UrlShortenerRepository>();
builder.Services.AddTransient<IUrlShortenerService, UrlShortenerService>();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(opt =>
{
    opt.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();