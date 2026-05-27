# 1. Título del Proyecto
## Plataforma de Streaming - Panel Principal

---

# 2. Descripción breve del problema que resuelve
El problema principal que resuelve esta aplicación es la falta de un sistema centralizado, ligero y estructurado para la administración de catálogos multimedia de streaming (películas y series). En entornos reales, el volumen de producciones audiovisuales crece exponencialmente, haciendo que la búsqueda manual, indexación y filtrado de contenidos sea ineficiente para los administradores de plataformas. 

Esta aplicación soluciona dicho problema mediante una interfaz gráfica que automatiza la carga masiva de datos de prueba, asigna identificadores únicos estandarizados (como `P` para Películas y `S` para Series), y ofrece operaciones instantáneas de consulta y depuración (búsqueda y eliminación por ID). Con esto se optimiza el tiempo de respuesta en la gestión del catálogo y se minimiza el margen de error humano en la indexación de datos multimedia.

---

# 3. Integrantes del equipo y rol de cada uno
* **Mauricio:** Desarrollador de Software / Diseño de la interfaz gráfica (Windows Forms) y lógica de componentes.
* **Cristian:** Desarrollador de Software / Desarrollo del motor de búsqueda y gestión de datos en memoria.
* **Tomás:** Desarrollador de Software / Estructuración de datos del catálogo, lógica de eliminación y documentación.

---

# 4. Tecnologías y versiones utilizadas
* **Lenguaje de Programación:** C#
* **Framework de Desarrollo:** .NET 8.0-windows (Windows Forms)
* **Entorno de Desarrollo (IDE):** Visual Studio 2022 / VS Code
* **Control de Versiones:** Git y GitHub

---

# 5. Requisitos previos para ejecutar el proyecto
Antes de clonar e instalar el proyecto, asegúrate de contar con los siguientes elementos instalados en tu equipo:
* Sistema Operativo: **Windows** (requerido para la ejecución nativa de la interfaz de Windows Forms).
* **SDK de .NET 8.0** o superior.
* **Visual Studio 2022** con la carga de trabajo "Desarrollo de escritorio de .NET" o **VS Code** con el conjunto de extensiones de C# de Microsoft.

---

# 6. Pasos de instalación
Sigue estas instrucciones para clonar y preparar el entorno de desarrollo de forma local:

1. **Clonar el repositorio:**
   ```bash
   git clone [https://github.com/josemarin067-dot/Proyecto-StreamingHerramientas.git](https://github.com/josemarin067-dot/Proyecto-StreamingHerramientas.git)

   # 7. Pasos de ejecución
Sigue estos pasos para compilar y ejecutar la aplicación desde tu entorno:

### Desde Visual Studio 2022:
1. Abre el archivo de solución (`.sln`) en Visual Studio.
2. Asegúrate de que la configuración de compilación esté en **Debug** o **Release**.
3. Presiona el botón **Iniciar** (o la tecla `F5`) para compilar y ejecutar la interfaz gráfica.

### Desde la Terminal (CLI de .NET):
1. Abre tu terminal en la carpeta raíz del proyecto (donde se encuentra el archivo `.csproj`).
2. Ejecuta el comando de restauración de dependencias:
   ```bash
   dotnet restore
   ```
3. Compila y ejecuta la aplicación con el siguiente comando:
   ```bash
   dotnet run
   ```

---

# 8. Ejemplo de uso
Una vez que la interfaz gráfica esté en pantalla, el flujo de uso estándar es el siguiente:

1. **Carga Inicial:** Haz clic en el botón de carga masiva para poblar la tabla con el catálogo de prueba (películas y series).
2. **Visualización:** Observa cómo los identificadores se autogeneran anteponiendo `P` para películas y `S` para series.
3. **Búsqueda de Elementos:** Introduce un ID válido en el campo de texto de búsqueda y presiona el botón correspondiente para filtrar la información de inmediato.
4. **Eliminación de Contenido:** Selecciona un registro o ingresa su ID en el campo de eliminación para depurarlo del catálogo en tiempo real.

---

# 9. Estructura del proyecto
La organización del código fuente sigue el patrón estándar de una aplicación de escritorio en C#:

```text
Proyecto-StreamingHerramientas/
├── .gitignore              # Archivos y carpetas omitidos por Git
├── README.md               # Documentación principal del proyecto
├── ProyectoStreaming.sln    # Archivo de solución de Visual Studio
└── App/                    # Carpeta principal del código fuente
    ├── App.csproj          # Archivo de configuración del proyecto .NET
    ├── Program.cs          # Punto de entrada principal de la aplicación
    ├── FormMain.cs         # Lógica de la interfaz gráfica principal
    ├── FormMain.Designer.cs# Código autogenerado del diseño visual
    └── Models/             # Modelos de datos y lógica de negocio
        ├── Catalogo.cs     # Motor de búsqueda y gestión en memoria
        ├── Pelicula.cs     # Clase del objeto Película (Hereda de Multimedia)
        └── Serie.cs        # Clase del objeto Serie (Hereda de Multimedia)
```

---

# 10. Capturas de pantalla
> *Nota: Esta sección se encuentra reservada para que el equipo agregue de forma local las imágenes de la interfaz gráfica una vez compilada la versión final en sus respectivos entornos.*

---

# 11. Arquitectura y diagramas UML
La aplicación utiliza una **Arquitectura en Capas Básica** orientada a objetos para separar la interfaz del usuario de la persistencia de datos en memoria:

* **Capa de Presentación (UI):** Controlada por Windows Forms (`FormMain`), que gestiona los eventos del usuario (clics, textos, tablas).
* **Capa de Lógica de Negocio (Models):** Clases base y heredadas que representan los elementos del catálogo y aplican las reglas de validación (IDs estructurados).
* **Capa de Datos:** Colecciones de datos en memoria alojadas en la clase de gestión central, permitiendo accesos y modificaciones rápidas.

```text
+---------------------------------------+

|         Capa de Presentación          |
|  (FormMain.cs / Windows Forms UI)     |
+------------------+--------------------+

                   |
                   v
+---------------------------------------+
|          Capa de Negocio              |
| (Catalogo.cs / Operaciones en memoria)|
+------------------+--------------------+

                   |
                   v
+---------------------------------------+
|          Modelos de Datos             |
|   (Pelicula.cs / Serie.cs / Base)     |
+---------------------------------------+
```

---

# 12. Funcionalidades implementadas
* **Carga automatizada:** Inicialización rápida de datos simulados para pruebas de rendimiento.
* **Clasificación estricta:** Diferenciación visual e indexada entre películas y series mediante prefijos (`P` y `S`).
* **Búsqueda indexada:** Filtro instantáneo de elementos a través de su identificador único.
* **Eliminación segura:** Depuración de registros en memoria con actualización inmediata de la interfaz gráfica.

---

# 13. Limitaciones conocidas
* **Persistencia temporal:** Al cerrar la aplicación, los datos modificados o eliminados se pierden debido a que el almacenamiento es estrictamente en memoria (RAM).
* **Dependencia de plataforma:** La interfaz gráfica de Windows Forms restringe la ejecución nativa de la aplicación a sistemas operativos Windows.

---

# 14. Mejoras futuras
* **Persistencia real:** Integrar una base de datos local (SQLite) o un sistema de archivos JSON para guardar los cambios.
* **Multiplataforma:** Migrar la interfaz gráfica a tecnologías modernas como .NET MAUI o Avalonia UI para dar soporte a Linux y macOS.
* **Módulo de estadísticas:** Añadir un panel gráfico que muestre el porcentaje de series frente a películas en el sistema.

---

# 15. Créditos, licencia y declaración de uso de IA
* **Desarrollado por:** Mauricio, Cristian y Tomás.
* **Licencia:** Este proyecto se distribuye bajo la Licencia MIT. Siéntete libre de usarlo, modificarlo y distribuirlo.
* **Declaración de uso de IA:** Se utilizaron herramientas de Inteligencia Artificial para la asistencia en la estructuración de la documentación técnica (README.md) y la optimización de sintaxis del código fuente.
