using Microsoft.EntityFrameworkCore;
using UrlShortener.Data;
using UrlShortener.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUrlRepository, UrlRepository>();
//builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("UrlShortenerDb"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
