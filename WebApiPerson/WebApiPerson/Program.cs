using Microsoft.EntityFrameworkCore;
using WebApiPerson.Context;
using WebApiPerson.Services;
using WebApiPerson.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios de SignalR
builder.Services.AddSignalR();

// Registrar el servicio de cron�metro como singleton
builder.Services.AddSingleton<CronometroService>();
builder.Services.AddSingleton<TemporizadorService>();

// Obtener la cadena de conexi�n de la configuraci�n
var connectionString = builder.Configuration.GetConnectionString("Connection");

// Configurar DbContext para la conexi�n a la base de datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Configurar controladores
builder.Services.AddControllers();

// Habilitar CORS para permitir solicitudes de cualquier origen
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin() // Permite cualquier origen
               .AllowAnyMethod() // Permite cualquier m�todo (GET, POST, etc.)
               .AllowAnyHeader(); // Permite cualquier encabezado
    });
});

// Agregar Swagger para documentaci�n de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuraci�n del middleware en funci�n del entorno
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Aplicar la pol�tica CORS
app.UseCors("AllowAll");

// Middleware para redirecci�n HTTPS y autorizaci�n
app.UseHttpsRedirection();
app.UseAuthorization();

// Mapeo de controladores
app.MapControllers();

// Mapeo de SignalR hub
app.MapHub<CronometroHub>("/hubs/cronometro");

// Iniciar la aplicaci�n
app.Run();
