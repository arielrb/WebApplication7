using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication7.Context;
using WebApplication7.Models;

namespace WebApplication7.Pages.Tareas
{
    public class editarModel : PageModel
    {       
        //Traigo una instancia del contexto para vincular
        private readonly TareasContext _contexto;
        //Defino el constructor de la clase
        public editarModel(TareasContext contexto)
        {
            _contexto = contexto;
        }
        //Instanciamos el modelo y le hacemos binding con la vista
        [BindProperty]
        public Tarea TareaEditable { set; get; }
        //El siguiente metodo busca la informacion de BBDD para mostrar por pantalla
        public async Task OnGet(int id)
        {
            //El id lo trae desde la vista index
            TareaEditable = await _contexto.Tareas.FindAsync(id);
        }
        //El siguiente metodo actualiza la informacion
        public async Task<IActionResult> OnPost() {
            if (ModelState.IsValid)
            {
                //Variable a editar
                var TareaEditada = await _contexto.Tareas.FindAsync(TareaEditable.TareaId);

                TareaEditada.Titulo = TareaEditable.Titulo;
                TareaEditada.CategoriaID = TareaEditable.CategoriaID;
                TareaEditada.Descripcion = TareaEditable.Descripcion;
                TareaEditada.EstadoTarea = TareaEditable.EstadoTarea;

                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
