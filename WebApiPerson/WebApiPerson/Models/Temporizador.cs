namespace WebApiPerson.Models
{
    public class Temporizador
    {
        public int id { get; set; }
        public TimeSpan? Duracion { get; set; }
        public TimeSpan TiempoTranscurrido { get; set; }
        public DateTime? Inicio { get; set; }
        public bool EstaCorriendo { get; set; }
        public bool AudioReproducido { get; set; } // Nueva propiedad


    }
}
