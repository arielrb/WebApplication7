using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication7.Models
{
    public class Categoria
    {
        //Atributos
        //[Key]
        public int CategoriaID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        //Ingorar este objeto en el formulario post
        [JsonIgnore]
        //Una categoria tiene asociada varias tareas
        public ICollection<Tarea> Tareas { get; set; }

    }
}
