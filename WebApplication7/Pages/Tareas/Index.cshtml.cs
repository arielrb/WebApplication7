using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication7.Context;
using WebApplication7.Models;

namespace WebApplication7.Pages.Tareas
{
    public class IndexModel : PageModel
    {
        //Traigo una instancia del contexto para vincular
        private readonly TareasContext _contexto;
        //Defino el constructor de la clase
        public IndexModel(TareasContext contexto)
        {
            _contexto = contexto;
        }
        //Defino una coleccion enumerable a pasar
        public IEnumerable<Tarea> TareasListadas { get; set; }
        //Metodo asincrono para llamar a la conexion
        public async Task OnGet()
        {
            TareasListadas = await _contexto.Tareas.ToListAsync();
        }
        public async Task<IActionResult> OnPostEliminar(int id)
        {
            //Buscamos e instanciamos el objeto por su id
            var TareaEliminar = await _contexto.Tareas.FindAsync(id);
            //Definimos la logica de eliminacion
            if (TareaEliminar != null)
            {
                _contexto.Tareas.Remove(TareaEliminar);
                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return NotFound("Esta tarea no existe!");
            }

        }
    }
}
