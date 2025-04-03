using Application.Domain.Interfaces;
using Application.Infrastructure.DataContext;
using Application.Infrastructure.Repositories;
using Application.Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Application.Domain.Entities;

//var builder = WebApplication.CreateBuilder(args);

//// Add DbContext
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DbContextConnectionstring") ??
//    throw new InvalidOperationException("Connection String 'DbContextConnectionstring' not found")));

//// Register services and repositories
//builder.Services.AddScoped(typeof(IFlightRepository<>), typeof(FlightRepository<>));
//builder.Services.AddScoped(typeof(IFlightServices<>), typeof(FlightServices<>));
////builder.Services.AddTransient<IFlightRepository<AirportInfoApi>, FlightRepository<AirportInfoApi>>();
////builder.Services.AddTransient<IFlightRepository<FlightInfo>, FlightRepository<FlightInfo>>();
//// Configure Swagger
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnTheWayWebApiProject", Version = "v1" });

//});
//// Add services to the container.
//builder.Services.AddHttpClient();
//builder.Services.AddControllers();

////Configure CORS
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigin", policy =>
//    {
//        policy.WithOrigins("https://localhost:44365")
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    });
//});

//var app = builder.Build();
//var serviceProvider = app.Services;
//var dbContext = serviceProvider.GetService<Application.Infrastructure.DataContext.ApplicationDbContext>();

//if (dbContext == null)
//{
//    throw new InvalidOperationException("ApplicationDbContext is not registered in DI.");
//}


//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnTheWayWebApiProject V1");

//    });
//    app.UseDeveloperExceptionPage();
//}

//app.UseHttpsRedirection();
//app.UseCors("AllowSpecificOrigin");

//// Ensure that the routing middleware is added after the CORS middleware
//app.UseRouting();

//app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

//app.Run();
var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbContextConnectionstring") ??
    throw new InvalidOperationException("Connection String 'DbContextConnectionstring' not found")));

// Register services and repositories
builder.Services.AddScoped(typeof(IFlightRepository<>), typeof(FlightRepository<>));
builder.Services.AddScoped(typeof(IServices<>), typeof(Services<>));

// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnTheWayWebApiProject", Version = "v1" });
});

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllers();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("https://localhost:44365")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnTheWayWebApiProject V1");
    });
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");

app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
