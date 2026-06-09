using Microsoft.EntityFrameworkCore;
using ScaffoldingV1.Models;

namespace ScaffoldingV1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Encuesta> Encuestas { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<OpcionRespuesta> OpcionesRespuesta { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }
        public DbSet<RespuestaDetalle> RespuestaDetalles { get; set; }
    }
}