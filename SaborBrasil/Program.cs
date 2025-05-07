using Microsoft.EntityFrameworkCore;
using SaborBrasil.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 13))));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles(); // Permite servir arquivos da pasta wwwroot

app.MapDefaultControllerRoute(); // Configura as rotas padrão para os controladores

app.Run();
