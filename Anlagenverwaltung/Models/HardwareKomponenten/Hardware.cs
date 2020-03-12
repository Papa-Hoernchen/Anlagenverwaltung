using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anlagenverwaltung.Models.HardwareKomponenten
{
    public abstract class Hardware
    {
        public int Id { get; set; }
        public string Produktname { get; set; }
        public string Produktnummer { get; set; }
        public string Modellnummer { get; set; }
        public string Seriennummer { get; set; }
        public double Einkaufspreis { get; set; }
        public DateTime Einkaufsdatum { get; set; }
    }
}