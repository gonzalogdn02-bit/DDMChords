using System.Collections.Generic;

namespace DDMChords.Models
{
    // Unificamos todo tu modelo en una sola clase maestra
    public class CancionModel
    {
        // Propiedades de tu Home.razor
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Tonalidad { get; set; } = string.Empty;
        public int Bpm { get; set; }
        public string NotaMusico { get; set; } = string.Empty;

        // Propiedades adicionales que traías de ModelosApp.cs
        public string Artista { get; set; } = string.Empty;
        public string TonoOriginal { get; set; } = "D";
        public string TonoActual { get; set; } = "D";
        public string LetraConAcordes { get; set; } = string.Empty;
        public string NombrePdf { get; set; } = string.Empty;

        public List<NotaBanda> Notas { get; set; } = new();
    }

    // La clase NotaBanda queda guardada acá mismo
    public class NotaBanda
    {
        public string Rol { get; set; } = string.Empty;
        public string Texto { get; set; } = string.Empty;
        public string Instrumento { get; set; } = string.Empty;
        public string ColorBorde { get; set; } = string.Empty;
    }
}