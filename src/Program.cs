using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_ci
{
    public class Calculadora
    {
        public int Sumar(int a, int b) => a + b;
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Agregar los servicios necesarios al contenedor de dependencias
            builder.Services.AddSingleton<Calculadora>();

            // Configuración de CORS para permitir solicitudes del frontend
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost", policy =>
                {
                    policy.WithOrigins("http://localhost:5174")  // Cambia el puerto si tu frontend está en otro
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Aplicar la política de CORS
            app.UseCors("AllowLocalhost");

            // Definir un endpoint para retornar "Hola CI!"
            app.MapGet("/", () => "Hola CI!");

            // Crear un endpoint para la función de suma
            app.MapGet("/sumar", (int a, int b, Calculadora calculadora) =>
            {
                var resultado = calculadora.Sumar(a, b);
                return Results.Ok(resultado);
            });

            // Iniciar la aplicación
            app.Run();
        }
    }
}
