using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anlagenverwaltung.Dto.SoftwareKomponentenDto
{
    public abstract class SoftwareDto
    {
        public int Id { get; set; }
        public string Aufgabe { get; set; }
        public string Name { get; set; }
        public string Hersteller { get; set; }
        public string Lizenznummer { get; set; }
        public double Einkaufspreis { get; set; }
        public DateTime Einkaufsdatum { get; set; }
        public string Version { get; set; }
    }
}