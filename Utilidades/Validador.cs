namespace PROYECTOSTREAMING.Utilidades
{
    public static class Validador
    {
        // Función auxiliar para verificar si un texto no está vacío
        public static bool EsTextoValido(string texto)
        {
            return !string.IsNullOrWhiteSpace(texto);
        }
    }
}