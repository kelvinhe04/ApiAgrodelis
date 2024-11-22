public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configurar CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()  // Permite cualquier origen
                      .AllowAnyMethod()  // Permite cualquier método (GET, POST, etc.)
                      .AllowAnyHeader();  // Permite cualquier encabezado
            });
        });

        // Añadir servicios al contenedor
        builder.Services.AddControllers();

        var app = builder.Build();

        // Usar CORS
        app.UseCors("AllowAll");

        app.MapControllers();
        app.Run();
    }
}
