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

        // Agregar servicios a Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Añadir servicios al contenedor
        builder.Services.AddControllers();

        var app = builder.Build();

        // Habilitar Swagger en desarrollo y producción
        app.UseSwagger();
        app.UseSwaggerUI();

        // Ruteo
        app.UseRouting();

        // Usar CORS
        app.UseCors("AllowAll");

        // Mapear controladores
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run();
    }
}
