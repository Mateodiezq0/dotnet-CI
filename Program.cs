var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/wordle/check", (string palabra) =>
{
    if (palabra.ToLower() == "perro")
        return Results.Ok("¡Correcto!");
    else
        return Results.Ok("Incorrecto.");
});

app.Run();
//aaa