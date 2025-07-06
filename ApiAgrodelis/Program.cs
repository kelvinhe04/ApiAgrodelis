using ApiAgrodelis.Datos;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // 1. CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });

        // 2. Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // 3. Controladores
        builder.Services.AddControllers();

        var app = builder.Build();

        // 4. Usar Swagger (habilitado siempre, opcionalmente puedes restringirlo)
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "API AgroDelis v1");
            c.RoutePrefix = "swagger"; // Esto permite acceder con /swagger
        });

        // 5. Middleware
        app.UseRouting();
        app.UseCors("AllowAll");

        // 6. Endpoints
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run();
        builder.Services.AddSingleton<Db>();

    }
}
