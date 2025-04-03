using Application.Application.Services;
using Application.Domain.Interfaces;
using Application.Infrastructure.DataContext;
using Application.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Step 1: Add DbContext to DI
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbContextConnectionstring") ??
    throw new InvalidOperationException("Connection String 'DbContextConnectionstring' not found")));

// Step 2: Register repositories and services
builder.Services.AddScoped(typeof(IFlightRepository<>), typeof(FlightRepository<>));
builder.Services.AddScoped(typeof(IServices<>), typeof(Services<>));

// Step 3: Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();

// Step 4: Configure CORS
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
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowSpecificOrigin");
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "dynamic",
    pattern: "{controller=Dynamic}/{action=Index}/{entity?}/{id?}");

app.Run();
