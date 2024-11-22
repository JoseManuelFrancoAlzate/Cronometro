namespace WebApiPerson.Models
{
    public class Cronometro
    {
        public int Id { get; set; }
        public TimeSpan TiempoTranscurrido { get; set; }
        public bool EstaCorriendo { get; set; }
        public DateTime? Inicio { get; set; }
    }
}
