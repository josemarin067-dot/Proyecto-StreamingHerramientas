namespace PROYECTOSTREAMING.Modelo
{
    public class Pelicula : Contenido
    {
        public string Director { get; set; }
        public int DuracionMinutos { get; set; }

        public Pelicula(string id, string titulo, int anio, string genero, string director, int duracionMinutos) 
            : base(id, titulo, anio, genero)
        {
            Director = director;
            DuracionMinutos = duracionMinutos;
        }

        public override string ObtenerDetalles()
        {
            return $"{base.ObtenerDetalles()} | Director: {Director} | Duración: {DuracionMinutos} min. (Película)";
        }
    }
}
