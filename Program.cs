// Program.cs (Integrado con tu código por defecto)

using Microsoft.EntityFrameworkCore; // Necesario para DbContextOptionsBuilder y UseSqlServer
using PortalGestionInterna.Data; // Asegúrate que el namespace de tu ApplicationDbContext sea correcto

var builder = WebApplication.CreateBuilder(args);

// 1. CONFIGURACIÓN DE LA CADENA DE CONEXIÓN
// Obtener la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// O, si la conexión se llama diferente en tu appsettings.json, usa ese nombre.
// Por ejemplo: var connectionString = builder.Configuration.GetConnectionString("AzureSQLConnection");


// Add services to the container.
// 2. REGISTRAR EL DBCONTEXT
// Añadir el ApplicationDbContext a los servicios de la aplicación.
// Configurar Entity Framework Core para usar SQL Server con la cadena de conexión obtenida.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();


// --- Si estás usando ASP.NET Core Identity para autenticación (opcional pero recomendado para un portal interno) ---
// Si no lo has añadido y quieres autenticación, necesitarías algo como:
// builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true) // O tu clase ApplicationUser personalizada
//    .AddEntityFrameworkStores<ApplicationDbContext>();
// Y tu ApplicationDbContext debería heredar de IdentityDbContext<TuClaseUsuario>
// --- Fin de la sección opcional de Identity ---


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Para servir CSS, JS, imágenes desde wwwroot. Esto es importante.

app.UseRouting();

// --- Si usas ASP.NET Core Identity, necesitarías esto antes de UseAuthorization ---
// app.UseAuthentication(); // Habilita la autenticación
// --- Fin de la sección opcional de Identity ---

app.UseAuthorization(); // Habilita la autorización

// Nota: app.MapStaticAssets() y .WithStaticAssets() en MapControllerRoute
// suelen ser para escenarios más específicos como Blazor WebAssembly con ASP.NET Core Hosted
// o cuando se sirven activos estáticos de manera diferente.
// Para una aplicación MVC/Razor Pages estándar, app.UseStaticFiles() es lo usual.
// Si tenías una razón específica para MapStaticAssets, puedes volver a evaluarlo.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
