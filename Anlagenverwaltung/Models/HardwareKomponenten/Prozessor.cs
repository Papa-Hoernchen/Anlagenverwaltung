using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anlagenverwaltung.Models.HardwareKomponenten
{
    public class Prozessor
    {
        public byte Id { get; set; }
        public string Hersteller { get; set; }
        public string Produktbezeichnung { get; set; }
        public float Einkaufspreis { get; set; }
        public DateTime Einkaufsdatum { get; set; }
        public int Kerne { get; set; }
        public float Taktfrequenz { get; set; }
        [NotMapped]
        public string HerstellerProdukt
        {
            get { return Hersteller + " " + Produktbezeichnung;}

        }

    }
}