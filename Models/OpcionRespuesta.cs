using System.ComponentModel.DataAnnotations;

namespace ScaffoldingV1.Models
{
    public class OpcionRespuesta
    {
        public int Id { get; set; }

        public int PreguntaId { get; set; }

        [Required]
        public required string Texto { get; set; }

        public int Valor { get; set; }

        public int Orden { get; set; }

        public Pregunta? Pregunta { get; set; }
        public ICollection<RespuestaDetalle>? RespuestaDetalles { get; set; }
    }
}