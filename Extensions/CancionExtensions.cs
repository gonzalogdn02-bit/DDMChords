using DDMChords.Models;

namespace DDMChords.Extensions
{
    public static class CancionExtensions
    {
        // Devuelve el BPM como string seguro para el HTML
        public static string ObtenerBpmString(this CancionModel? cancion)
        {
            if (cancion == null)
                return "80";
            return cancion.Bpm.ToString();
        }

        // Modifica el BPM de forma segura sin romper la propiedad
        public static void ModificarBpmSeguro(this CancionModel? cancion, int valor)
        {
            if (cancion == null) return;
            cancion.Bpm = cancion.Bpm + valor;
        }
    }
}