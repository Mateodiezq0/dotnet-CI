using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_ci
{
    public class Program
    {
        // Palabra objetivo (en un caso real se podría hacer dinámico o cargar desde una base de datos)
        private static readonly string PalabraObjetivo = "svelte";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Obtener la URL del frontend desde una variable de entorno
            var frontendUrl = builder.Configuration["FRONTEND_URL"] ?? "http://localhost:5174"; // Valor por defecto

            // Agregar servicios necesarios al contenedor de dependencias **antes** de Build()
            builder.Services.AddSingleton<Calculadora>();

            // Configuración de CORS para permitir solicitudes del frontend
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins(frontendUrl)  // Usando la variable de entorno
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Aplicar la política de CORS
            app.UseCors("AllowFrontend");

            // Definir un endpoint para retornar "Hola CI!"
            app.MapGet("/", () => "Hola CI!");

            // Crear un endpoint para la función de suma
            app.MapGet("/sumar", (int a, int b, Calculadora calculadora) =>
            {
                var resultado = calculadora.Sumar(a, b);
                return Results.Ok(resultado);
            });

            // Endpoint para comprobar la palabra (Wordle básico)
            app.MapGet("/comprobar", (string palabra) =>
            {
                if (string.IsNullOrEmpty(palabra))
                {
                    return Results.BadRequest("La palabra no puede estar vacía");
                }

                if (palabra.Equals(PalabraObjetivo, StringComparison.OrdinalIgnoreCase))
                {
                    return Results.Ok("¡Has adivinado la palabra!");
                }
                else
                {
                    return Results.Ok("Intenta de nuevo.");
                }
            });

            // Iniciar la aplicación
            app.Run();
        }
    }

    public class Calculadora
    {
        public int Sumar(int a, int b) => a + b;
    }
}
