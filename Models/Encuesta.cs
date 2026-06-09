using System.ComponentModel.DataAnnotations;

namespace ScaffoldingV1.Models
{
    public class Encuesta
    {
        public int Id { get; set; }

        [Required]
        public required string Titulo { get; set; } 

        [Required]
        public required string Descripcion { get; set; } 

        public DateTime FechaCreacion { get; set; }

        public bool Activa { get; set; }

        public ICollection<Pregunta>? Preguntas { get; set; }
        public ICollection<Respuesta>? Respuestas { get; set; }
    }
}