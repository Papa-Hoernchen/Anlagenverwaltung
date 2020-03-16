using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anlagenverwaltung.Models.HardwareKomponenten
{
    public class Festplatte : Hardware
    {
        public Festplatte()
        {
            this.Computers = new HashSet<Computer>();
        }
        public string Art { get; set; }
        public int Speicherkapazitaet { get; set; }
        public string Schnittstelle { get; set; }

        public virtual ICollection<Computer> Computers { get; set; }
    }
}