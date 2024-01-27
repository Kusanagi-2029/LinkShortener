using LinkShortener.Models;
using LinkShortener.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Настройка подключения к базе данных

/*
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LinkShortenerContext>(options =>
    options.UseNpgsql(connectionString));
    */
builder.Services.AddDbContext<LinkShortenerContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавление сервисов в контейнер.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IShortLinkService, ShortLinkService>();

var app = builder.Build();

// Добавление обработчиков запросов в конвейер обработки запросов.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
