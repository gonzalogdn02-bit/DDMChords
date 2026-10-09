using System;
using System.Collections.Generic;

namespace DDMChords.Models
{
    public class SetlistModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime Fecha { get; set; } = DateTime.Now;
        public List<int> CancionesIds { get; set; } = new List<int>();
    }
}
