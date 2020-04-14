using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anlagenverwaltung.Dto
{
    public class SonstigeAnlageDto
    {
        public int Id { get; set; }

        public string Gegenstand { get; set; }
        public string Bezeichnung { get; set; }
        public float Einkaufspreis { get; set; }
        public DateTime Einkaufsdatum { get; set; }

        public KontoDto Konto { get; set; }
        public int? KontoId { get; set; }

        public int Nutzungsdauer { get; set; }
    }
}