using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anlagenverwaltung.Models
{
    public class SonstigeAnlage
    {
        public int Id { get; set; }

        public string Gegenstand { get; set; }
        public string Bezeichnung { get; set; }
        public float Einkaufspreis { get; set; }
        public DateTime Einkaufsdatum { get; set; }

        public Konto Konto { get; set; }
        public int? KontoId { get; set; }

        public int Nutzungsdauer { get; set; }
    }
}