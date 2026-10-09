using System.Collections.Generic;

namespace DDMChords.Models
{
    public class CancionModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Artista { get; set; } = string.Empty;
        public string Tonalidad { get; set; } = string.Empty;
        public int Bpm { get; set; }
        public string NotaMusico { get; set; } = string.Empty;

        public string TonoOriginal { get; set; } = "C";
        public string TonoActual { get; set; } = "C";
        public string LetraConAcordes { get; set; } = string.Empty;
        public string NombrePdf { get; set; } = string.Empty;

        public List<NotaBanda> Notas { get; set; } = new List<NotaBanda>();
    }

    public class NotaBanda
    {
        public string Rol { get; set; } = string.Empty;
        public string Texto { get; set; } = string.Empty;
        public string Instrumento { get; set; } = string.Empty;
        public string ColorBorde { get; set; } = string.Empty;
    }
}
