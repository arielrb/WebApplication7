using Microsoft.EntityFrameworkCore;
using WebApplication7.Models;

namespace WebApplication7.Context
{
    public class TareasContext : DbContext
    {
        //DbSets, los que se van a convertir en tablas
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        //Constructor
        public TareasContext(DbContextOptions<TareasContext> options) : base(options) {
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {//aca definimos todos los metodos que alteran nuestras tablas
            List<Categoria> categoriaInit = new List<Categoria>();

            //Creamos la tabla categoria
            modelBuilder.Entity<Categoria>(categoria =>
            {
                //Definimos que categoria será una tabla
                categoria.ToTable("Categoria");

                //Definimos las relaciones
                categoria.HasKey(p => p.CategoriaID);
                //Definimos las propiedades de las tablas
                categoria.Property(p => p.Nombre).IsRequired(false).HasMaxLength(150);
                categoria.Property(p => p.Descripcion).IsRequired().HasMaxLength(300);
            });

            modelBuilder.Entity<Tarea>(tarea =>
            {
                //Definimos el modelo
                tarea.ToTable("Tarea");

                //definimos la relacion con categorias 
                tarea.HasKey(p => p.TareaId);
                tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaID);
                //definimos las propiedades 
                tarea.Property(p => p.Titulo).HasMaxLength(100);

                tarea.Property(p => p.Descripcion);

                tarea.Property(p => p.PrioridadTarea);

                tarea.Property(p => p.FechaCreacion);
                tarea.Property(p => p.Procrastinable);
                tarea.Property(p => p.EstadoTarea);

                //Ignoramos las propiedades que no queremos que persistan
                tarea.Ignore(p => p.Resumen);

            });
        }
    }
}
