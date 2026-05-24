using System;
using System.Drawing;
using System.Windows.Forms;
using PROYECTOSTREAMING.Modelo;
using PROYECTOSTREAMING.Servicios;

namespace PROYECTOSTREAMING
{
    public partial class Form1 : Form
    {
        private readonly CatalogoServicio _servicio;
        
        // Elementos visuales que tendrá la ventana
        private ListBox lstCatalogo;
        private TextBox txtIdBuscar;
        private Button btnBuscar;
        private Button btnEliminar;
        private Button btnCargarPrueba;

        public Form1()
        {
            // Inicializamos el cerebro del sistema
            _servicio = new CatalogoServicio();
            
            ConfigurarVentana();
            InicializarComponentes();
        }

        private void ConfigurarVentana()
        {
            this.Text = "Plataforma de Streaming - Panel Principal";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(15, 15, 15); // Fondo oscuro estilo Netflix
        }

        private void InicializarComponentes()
        {
            // 1. Lista visual para mostrar el catálogo
            lstCatalogo = new ListBox();
            lstCatalogo.Location = new Point(30, 80);
            lstCatalogo.Size = new Size(720, 260);
            lstCatalogo.BackColor = Color.FromArgb(30, 30, 30);
            lstCatalogo.ForeColor = Color.White;
            lstCatalogo.Font = new Font("Segoe UI", 11);
            this.Controls.Add(lstCatalogo);

            // 2. Cuadro de texto para escribir el ID a buscar/eliminar
            txtIdBuscar = new TextBox();
            txtIdBuscar.Location = new Point(30, 380);
            txtIdBuscar.Size = new Size(150, 30);
            txtIdBuscar.Font = new Font("Segoe UI", 11);
            this.Controls.Add(txtIdBuscar);

            // 3. Botón Buscar
            btnBuscar = new Button();
            btnBuscar.Text = "Buscar ID";
            btnBuscar.Location = new Point(190, 378);
            btnBuscar.Size = new Size(100, 32);
            btnBuscar.BackColor = Color.FromArgb(50, 50, 50);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Click += BtnBuscar_Click;
            this.Controls.Add(btnBuscar);

            // 4. Botón Eliminar
            btnEliminar = new Button();
            btnEliminar.Text = "Eliminar ID";
            btnEliminar.Location = new Point(300, 378);
            btnEliminar.Size = new Size(100, 32);
            btnEliminar.BackColor = Color.FromArgb(229, 9, 20); // Rojo
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Click += BtnEliminar_Click;
            this.Controls.Add(btnEliminar);

            // 5. Botón para cargar datos simulados automáticamente
            btnCargarPrueba = new Button();
            btnCargarPrueba.Text = "Cargar Datos de Prueba";
            btnCargarPrueba.Location = new Point(30, 25);
            btnCargarPrueba.Size = new Size(200, 35);
            btnCargarPrueba.BackColor = Color.FromArgb(0, 80, 136); // Azul
            btnCargarPrueba.ForeColor = Color.White;
            btnCargarPrueba.Click += BtnCargarPrueba_Click;
            this.Controls.Add(btnCargarPrueba);
        }

        // EVENTOS DE LOS BOTONES

        private void ActualizarListaVisual()
        {
            lstCatalogo.Items.Clear();
            foreach (var contenido in _servicio.ObtenerTodo())
            {
                // POLIMORFISMO EN ACCIÓN: Se llama a ObtenerDetalles() y C# sabe 
                // automáticamente si debe usar el formato de Película o de Serie.
                lstCatalogo.Items.Add(contenido.ObtenerDetalles());
            }
        }
        private void BtnCargarPrueba_Click(object sender, EventArgs e)
        {
            // 1. LIMPIAR EL CATÁLOGO: Primero vaciamos la lista interna para que no se dupliquen
            // los datos si el usuario presiona el botón varias veces.
            var todoElContenido = _servicio.ObtenerTodo();
            
            // Eliminamos al revés para evitar errores de índice al vaciar la lista
            for (int i = todoElContenido.Count - 1; i >= 0; i--)
            {
                _servicio.EliminarContenido(todoElContenido[i].Id);
            }

            // 2. REPOBLAR EL CATÁLOGO: Volvemos a meter los datos originales limpios
            // --- PELÍCULAS DE PRUEBA ---
            _servicio.AgregarContenido(new Pelicula("P01", "Inception", 2010, "Ciencia Ficción", "Christopher Nolan", 148));
            _servicio.AgregarContenido(new Pelicula("P02", "Spider-Man: Into the Spider-Verse", 2018, "Animación", "Bob Persichetti", 117));
            _servicio.AgregarContenido(new Pelicula("P03", "The Dark Knight", 2008, "Acción / Drama", "Christopher Nolan", 152));
            _servicio.AgregarContenido(new Pelicula("P04", "Interstellar", 2014, "Ciencia Ficción", "Christopher Nolan", 169));
            _servicio.AgregarContenido(new Pelicula("P05", "Shrek 2", 2004, "Comedia / Animación", "Andrew Adamson", 93));

            // --- SERIES DE PRUEBA ---
            _servicio.AgregarContenido(new Serie("S01", "Stranger Things", 2016, "Drama / Fantasía", 4, 9));
            _servicio.AgregarContenido(new Serie("S02", "Breaking Bad", 2008, "Drama / Suspenso", 5, 13));
            _servicio.AgregarContenido(new Serie("S03", "Attack on Titan", 2013, "Anime / Acción", 4, 22));
            _servicio.AgregarContenido(new Serie("S04", "The Office", 2005, "Comedia / Mockumentary", 9, 22));
            _servicio.AgregarContenido(new Serie("S05", "Arcane", 2021, "Animación / Ciencia Ficción", 2, 9));
            
            // 3. ACTUALIZAR LA PANTALLA
            ActualizarListaVisual();
            
            // ¡OJO! Quitamos la línea que desactivaba el botón. Ahora el botón se queda 
            // siempre activo para que funcione como un botón de "Reiniciar Catálogo".
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string id = txtIdBuscar.Text.Trim();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Por favor, escribe un ID para buscar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Contenido encontrado = _servicio.BuscarPorId(id);
            if (encontrado != null)
            {
                MessageBox.Show($"¡Encontrado!\n\n{encontrado.ObtenerDetalles()}", "Resultado de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se encontró ningún contenido con ese ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            string id = txtIdBuscar.Text.Trim();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Por favor, escribe un ID para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool exito = _servicio.EliminarContenido(id);
            if (exito)
            {
                MessageBox.Show($"El contenido con ID [{id}] fue eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarListaVisual();
                txtIdBuscar.Clear();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar. ID no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
