using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication7.Context;
using WebApplication7.Models;

var builder = WebApplication.CreateBuilder(args);

//conexion a BBDD en memoria
//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDb"));
//conexion a SQLSERVER
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));
//Agragamos Razor Pages
builder.Services.AddRazorPages();
var app = builder.Build();


//MAPEOS

//GET
//app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("BBDD En memoria!" + dbContext.Database.IsInMemory());
});
app.MapGet("/listar/tareas", ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas);
});
app.MapGet("/listar/categorias", ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Categorias);
});
//POST
app.MapPost("/guardar/tarea", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(tarea);
    //await dbContext.Tareas.AddAsync(tarea); es otra forma de hacerlo

    await dbContext.SaveChangesAsync();

    return Results.Ok("Tarea almacenada con exito!");
});
app.MapPost("/guardar/categoria", async ([FromServices] TareasContext dbContext, [FromBody] Categoria categoria) =>
{
    await dbContext.AddAsync(categoria);

    await dbContext.SaveChangesAsync();

    return Results.Ok("Categoria almacenada con exito!");
});
//PUT
app.MapPut("/actualizar/tarea/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] int id) =>
{
    var tareaActual = dbContext.Tareas.Find(id);

    if (tareaActual != null)
    {
        tareaActual.CategoriaID = tarea.CategoriaID;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;
        tareaActual.Descripcion = tarea.Descripcion;

        await dbContext.SaveChangesAsync();

        return Results.Ok("Tarea actualizada correctamente!");

    }

    return Results.NotFound("esto no existe!");
});
app.MapPut("/actualizar/categoria/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Categoria categoria, [FromRoute] int id) =>
{
    var categoriaActual = dbContext.Categorias.Find(id);

    if (categoriaActual != null)
    {
        categoriaActual.CategoriaID = categoria.CategoriaID;
        categoriaActual.Nombre = categoria.Nombre;
        categoriaActual.Descripcion = categoria.Descripcion;

        await dbContext.SaveChangesAsync();

        return Results.Ok("Tarea actualizada correctamente!");

    }

    return Results.NotFound("esto no existe!");
});
//DELETE
app.MapDelete("/eliminar/tarea/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] int id) =>
{
    var tareaActual = dbContext.Tareas.Find(id);

    if (tareaActual != null)
    {
        dbContext.Remove(tareaActual);

        await dbContext.SaveChangesAsync();

        return Results.Ok("Tarea eliminada correctamente!");

    }

    return Results.NotFound();
});
app.MapDelete("/eliminar/categoria/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] int id) =>
{
    var categoriaActual = dbContext.Categorias.Find(id);

    if (categoriaActual != null)
    {
        dbContext.Remove(categoriaActual);

        await dbContext.SaveChangesAsync();

        return Results.Ok("Categoria eliminada correctamente!");

    }

    return Results.NotFound();
});

app.UseHttpsRedirection();
//Para los estilos
app.UseStaticFiles();

app.UseRouting();

//Para mapear las paginas de Razor!
app.MapRazorPages();

app.Run();