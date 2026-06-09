namespace ScaffoldingV1.Models
{
    public class RespuestaDetalle
    {
        public int Id { get; set; }

        public int RespuestaId { get; set; }

        public int PreguntaId { get; set; }

        public int? OpcionRespuestaId { get; set; }

        public required string TextoRespuesta { get; set; }

        public Respuesta? Respuesta { get; set; }
        public Pregunta? Pregunta { get; set; }
        public OpcionRespuesta? OpcionRespuesta { get; set; }
    }
}