using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DDMChords.Services
{
    public class TransposerService
    {
        private readonly string[] EscalaSostenidos = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
        private readonly string[] EscalaBemoles =    { "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab", "A", "Bb", "B" };
        
        public string TransponerAcordes(string letra, string tonoOriginal, string tonoActual)
        {
            if (string.IsNullOrWhiteSpace(letra) || tonoOriginal == tonoActual) return letra;
            
            int semitonos = ObtenerDiferenciaSemitonos(tonoOriginal, tonoActual);
            if (semitonos == 0) return letra;

            // Determinar si el tono actual prefiere bemoles (F y cualquier bemol)
            bool usarBemoles = tonoActual.Contains("b") || tonoActual.StartsWith("F") && !tonoActual.Contains("#");

            var lineas = letra.Split('\n');
            for (int i = 0; i < lineas.Length; i++)
            {
                if (EsLineaDeAcordes(lineas[i]))
                {
                    lineas[i] = TransponerLinea(lineas[i], semitonos, usarBemoles);
                }
            }
            return string.Join('\n', lineas);
        }

        public int ObtenerDiferenciaSemitonos(string tonoOriginal, string tonoActual)
        {
            string baseOriginal = Normalizar(tonoOriginal).Replace("m", "");
            string baseActual = Normalizar(tonoActual).Replace("m", "");

            int indexOriginal = Array.IndexOf(EscalaSostenidos, baseOriginal);
            int indexActual = Array.IndexOf(EscalaSostenidos, baseActual);
            
            if (indexOriginal == -1 || indexActual == -1) return 0;

            int diff = indexActual - indexOriginal;
            if (diff < 0) diff += 12;
            return diff;
        }

        private string Normalizar(string nota) => nota.Replace("Db", "C#").Replace("Eb", "D#").Replace("Gb", "F#").Replace("Ab", "G#").Replace("Bb", "A#");

        private bool EsLineaDeAcordes(string linea)
        {
            if (string.IsNullOrWhiteSpace(linea)) return false;
            var words = linea.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int chordCount = 0;
            var regex = new Regex(@"^[A-G][b#]?(m|maj7|7|sus4|dim)?$");
            foreach (var word in words) { if (regex.IsMatch(word)) chordCount++; }
            return chordCount > 0 && ((double)chordCount / words.Length) > 0.6;
        }

        private string TransponerLinea(string linea, int semitonos, bool usarBemoles)
        {
            return Regex.Replace(linea, @"[A-G][b#]?(m|maj7|7|sus4|dim)?", m =>
            {
                string acorde = m.Value;
                string raiz = Regex.Match(acorde, @"^[A-G][b#]?").Value;
                string resto = acorde.Substring(raiz.Length);
                return TransponerRaiz(raiz, semitonos, usarBemoles) + resto;
            });
        }

        private string TransponerRaiz(string raiz, int semitonos, bool usarBemoles)
        {
            int index = Array.IndexOf(EscalaSostenidos, Normalizar(raiz));
            if (index == -1) return raiz;
            
            int newIndex = (index + semitonos) % 12;
            if (newIndex < 0) newIndex += 12;
            
            return usarBemoles ? EscalaBemoles[newIndex] : EscalaSostenidos[newIndex];
        }
    }
}
