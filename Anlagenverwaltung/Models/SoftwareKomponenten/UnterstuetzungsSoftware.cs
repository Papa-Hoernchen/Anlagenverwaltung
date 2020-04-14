using System;
using System.Collections.Generic;
using Anlagenverwaltung.Models.HardwareKomponenten;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anlagenverwaltung.Models.SoftwareKomponenten
{
    public class Unterstuetzungssoftware
    {
        public Unterstuetzungssoftware()
        {
            this.Computer = new HashSet<Computer>();
        }

        public int Id { get; set; }

        public string Art { get; set; }
        public string Hersteller { get; set; }
        public string Bezeichnung { get; set; }
        public string Lizenznummer { get; set; }
        public float Einkaufspreis { get; set; }
        public DateTime Einkaufsdatum { get; set; }

        public virtual ICollection<Computer> Computer { get; set; }

        public Konto Konto { get; set; }
        public int? KontoId { get; set; }
    }
}