// Archivo: Pages/Home.razor.cs
using System.Collections.Generic;
using DDMChords.Models;

namespace DDMChords.Pages
{
    public partial class Home
    {
        public bool UsuarioAutenticado { get; set; } = false;
        public string instSeleccionado { get; set; } = "Guitarra Eléctrica";
        public Cancion cancion { get; set; } = new Cancion { Titulo = "Digno", Artista = "Marcos Brunet" };

        public List<string> listaInstrumentos { get; set; } = new() { "Voz Principal", "Coro 1", "Guitarra Eléctrica", "Gtr Acústica", "Teclado", "Batería" };
        public List<string> tonosMayores { get; set; } = new() { "C", "Db", "D", "Eb", "E", "F", "F#", "G", "Ab", "A", "Bb", "B" };

        public List<NotaBanda> listaNotas { get; set; } = new() {
            new NotaBanda { Instrumento = "Guitarra Eléctrica", Texto = "Acompañar suave en el final junto al teclado.", ColorBorde = "#a855f7" },
            new NotaBanda { Instrumento = "Voz Principal", Texto = "Terminamos muy suave en el cierre.", ColorBorde = "#f59e0b" }
        };

        public void Ingresar()
        {
            usuarioAutenticado = true;
        }
    }
}