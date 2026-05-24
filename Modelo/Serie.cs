namespace PROYECTOSTREAMING.Modelo
{
    public class Serie : Contenido
    {
        public int Temporadas { get; set; }
        public int EpisodiosPorTemporada { get; set; }

        public Serie(string id, string titulo, int anio, string genero, int temporadas, int episodiosPorTemporada) 
            : base(id, titulo, anio, genero)
        {
            Temporadas = temporadas;
            EpisodiosPorTemporada = episodiosPorTemporada;
        }

        public override string ObtenerDetalles()
        {
            return $"{base.ObtenerDetalles()} | {Temporadas} Temp. / {EpisodiosPorTemporada} Caps. (Serie)";
        }
    }
}