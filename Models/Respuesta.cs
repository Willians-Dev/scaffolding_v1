namespace ScaffoldingV1.Models
{
    public class Respuesta
    {
        public int Id { get; set; }

        public int EncuestaId { get; set; }

        public DateTime Fecha { get; set; }


        public required string NombreRespondente { get; set; }

        public required string Observacion { get; set; }

        public Encuesta? Encuesta { get; set; }
        public ICollection<RespuestaDetalle>? RespuestaDetalles { get; set; }
    }
}