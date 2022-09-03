using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication7.Context;
using WebApplication7.Models;

namespace WebApplication7.Pages.Tareas
{
    public class guardarModel : PageModel
    {        
        //Traigo una instancia del contexto para vincular
        private readonly TareasContext _contexto;
        //Defino el constructor de la clase
        public guardarModel(TareasContext contexto)
        {
            _contexto = contexto;
        }
        //Traemos el modelo y le hacemos binding
        [BindProperty]
        public Tarea tareaGuardable { set; get; } 
        public void OnGet()
        {
        }
        //Metodo asincrono para guardar la informacion
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) { 
                return Page(); 
            }
            //Fecha actual
            tareaGuardable.FechaCreacion = DateTime.Now;
            //Añadir el objeto tarea
            _contexto.Add(tareaGuardable);
            await _contexto.SaveChangesAsync();
            return RedirectToPage("Index");

        }
    }
}
