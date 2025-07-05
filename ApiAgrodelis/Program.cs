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
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });

        // Añadir servicios al contenedor
        builder.Services.AddControllers();

        var app = builder.Build();

        // 🔧 Esta línea es necesaria
        app.UseRouting();

        // Usar CORS
        app.UseCors("AllowAll");

        // Habilitar mapeo de controladores
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run();
    }
}
