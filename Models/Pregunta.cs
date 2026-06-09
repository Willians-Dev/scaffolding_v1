using System.ComponentModel.DataAnnotations;

namespace ScaffoldingV1.Models
{
    public class Pregunta
    {
        public int Id { get; set; }

        public int EncuestaId { get; set; }

        [Required]
        public required string Texto { get; set; }

        [Required]
        public required string Tipo { get; set; } 

        public int Orden { get; set; }

        public Encuesta? Encuesta { get; set; }
        public ICollection<OpcionRespuesta>? OpcionesRespuesta { get; set; }
        public ICollection<RespuestaDetalle>? RespuestaDetalles { get; set; }
    }
}