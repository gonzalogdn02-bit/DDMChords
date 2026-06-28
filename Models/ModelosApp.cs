using System.Collections.Generic;

namespace DDMChords.Models
{
    public class Cancion
    {
        public string Titulo { get; set; } = "";
        public string Artista { get; set; } = "";
        public string TonoOriginal { get; set; } = "D";
        public string TonoActual { get; set; } = "D";
        public string LetraConAcordes { get; set; } = "";
        public string NombrePdf { get; set; } = ""; // Para simular o guardar el archivo subido
        public List<NotaBanda> Notas { get; set; } = new();
    }

    public class NotaBanda
    {
        public string Rol { get; set; } = "";
        public string Texto { get; set; } = "";
        public string Instrumento { get; internal set; }
        public string ColorBorde { get; internal set; }
    }
}