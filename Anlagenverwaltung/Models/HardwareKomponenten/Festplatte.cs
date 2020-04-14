using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anlagenverwaltung.Models.HardwareKomponenten
{
    public class Festplatte
    {
        public Festplatte()
        {
            this.Computers = new HashSet<Computer>();
        }

        [Display(Name = "Festplatte")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Hersteller { get; set; }
        public string Produktbezeichnung { get; set; }
        public float Einkaufspreis { get; set; }
        public DateTime Einkaufsdatum { get; set; }

        public string Art { get; set; }
        public int Speicherkapazitaet { get; set; }
        public string Schnittstelle { get; set; }

        [NotMapped]
        public string HerstellerProdukt
        {
            get { return Hersteller + " " + Produktbezeichnung; }
        }

        public virtual ICollection<Computer> Computers { get; set; }
    }
}