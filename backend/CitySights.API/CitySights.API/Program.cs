using CitySights.Application.Services;
using CitySights.DataAccess;
using CitySights.DataAccess.Mappings;
using CitySights.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(DataBaseMappings));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISightService, SightService>();
builder.Services.AddScoped<ISightRepository, SightRepository>();

builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewSrvice, ReviewSrvice>();

builder.Services.AddDbContext<CitySightDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(CitySightDbContext)));
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
