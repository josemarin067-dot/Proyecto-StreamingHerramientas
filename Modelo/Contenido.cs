namespace PROYECTOSTREAMING.Modelo
{
    public abstract class Contenido
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public int Anio { get; set; }
        public string Genero { get; set; }

        protected Contenido(string id, string titulo, int anio, string genero)
        {
            Id = id;
            Titulo = titulo;
            Anio = anio;
            Genero = genero;
        }

        public virtual string ObtenerDetalles()
        {
            return $"[{Id}] {Titulo} ({Anio}) - Género: {Genero}";
        }
    }
}