using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anlagenverwaltung.Models.HardwareKomponenten
{
    public class Maus
    {
        public byte Id { get; set; }
        public string Hersteller { get; set; }
        public string Produktbezeichnung { get; set; }
        public float Einkaufspreis { get; set; }
        public DateTime Einkaufsdatum { get; set; }
        public string Art { get; set; }
        [NotMapped]
        public string HerstellerProdukt
        {
            get { return Hersteller + " " + Produktbezeichnung; }
        }
    }
}