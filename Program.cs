using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {

        Title = "Tarea 6",
        Version = "v1",
        Description = "Documentación de la API con Swagger"

    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
        c.RoutePrefix = string.Empty; // Swagger estará en la ruta raíz
    });
}

app.MapGet("/", () => "Hello World!");

var trueGroup = app.MapGroup("/asignacion").WithTags("Asignaciones").WithDescription("Rutas de las asignaciones.");

trueGroup.MapGet("/noticias", () => Paso1.Ejecutar());

trueGroup.MapPost("/registro_usuario", (Usuario u) => ManejadorUsuario.Registro(u));

trueGroup.MapPost("/iniciar_sesion", (DatosLogin dl) => ManejadorUsuario.IniciarSesion(dl));

app.Run();
