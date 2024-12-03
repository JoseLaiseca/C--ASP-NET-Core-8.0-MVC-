using Microsoft.EntityFrameworkCore;
using EjemploReporte.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura el DbContext con la cadena de conexi�n
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agrega servicios al contenedor (MVC con vistas)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuraci�n del pipeline de middleware

// Manejo de errores en producci�n
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HTTP Strict Transport Security
}

// Redirecci�n HTTPS
app.UseHttpsRedirection();

// Middleware para servir archivos est�ticos (desde wwwroot)
app.UseStaticFiles(); // Asegura que se sirvan recursos como productos.js

// Middleware para enrutar peticiones
app.UseRouting();

// Configura las rutas predeterminadas
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Productos}/{action=Index}/{id?}");
});

// Middleware para manejar autorizaci�n (si se requiere en el futuro)
app.UseAuthorization();

// Inicia la aplicaci�n
app.Run();
