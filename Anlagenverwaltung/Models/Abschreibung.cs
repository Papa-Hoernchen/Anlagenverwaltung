using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anlagenverwaltung.Models
{
    public class Abschreibung
    {
        public int Id { get; set; }
        public int KontoNr { get; set; }
        public string Name { get; set; }
        public DateTime Anschaffungsdatum { get; set; }
        public float Anschaffungskosten { get; set; }
        public int Nutzungsdauer { get; set; }

    }
}