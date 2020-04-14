using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anlagenverwaltung.Models.SoftwareKomponenten
{
    public class Betriebssystem
    {
        public int Id { get; set; }

        public string Art { get; set; }
        public string Hersteller { get; set; }
        public string Bezeichnung { get; set; }
        public string Lizenznummer { get; set; }
        public float Einkaufspreis { get; set; }
        public DateTime Einkaufsdatum { get; set; }

        [NotMapped]
        public string HerstellerProdukt
        {
            get { return Hersteller + " " + Bezeichnung; }

        }

        public Konto Konto { get; set; }
        public int? KontoId { get; set; }
    }
}