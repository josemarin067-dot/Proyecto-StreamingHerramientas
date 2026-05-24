using System.Collections.Generic;
using System.Linq;
using PROYECTOSTREAMING.Modelo;

namespace PROYECTOSTREAMING.Servicios
{
    public class CatalogoServicio
    {
        // Esta lista almacenará tanto películas como series juntas gracias a la herencia
        private readonly List<Contenido> _catalogo;

        public CatalogoServicio()
        {
            _catalogo = new List<Contenido>();
        }

        // 1. Operación: CREAR (Agregar al catálogo)
        public void AgregarContenido(Contenido nuevoContenido)
        {
            _catalogo.Add(nuevoContenido);
        }

        // 2. Operación: LISTAR (Obtener todos los elementos)
        public List<Contenido> ObtenerTodo()
        {
            return _catalogo;
        }

        // 3. Operación: BUSCAR (Por ID)
        public Contenido BuscarPorId(string id)
        {
            return _catalogo.FirstOrDefault(c => c.Id == id);
        }

        // 4. Operación: ELIMINAR (Por ID)
        public bool EliminarContenido(string id)
        {
            Contenido encontrado = BuscarPorId(id);
            if (encontrado != null)
            {
                _catalogo.Remove(encontrado);
                return true; // Se eliminó con éxito
            }
            return false; // No se encontró el ID
        }
    }
}