using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication7.Models
{
    public class Tarea
    {
        //Atributos
        //[Key]
        public int TareaId { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Descripcion { get; set; }
        //[ForeignKey("CategoriaID")]
        //Varias tareas tienen asociada 1 categoria
        public int CategoriaID { get; set; }
        public Categoria Categoria { get; set; }
        public Prioridad PrioridadTarea { get; set; }
        public bool Procrastinable { get; set; }
        public Estado EstadoTarea { get; set; }
        [NotMapped]
        public string Resumen { get; set; }


    }
    public enum Prioridad
    {
        Alta,
        Media,
        Baja
    }
    public enum Estado
    {
        Completado,
        Pendiente,
        Transicion
    }
}
