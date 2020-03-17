using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anlagenverwaltung.Models.HardwareKomponenten
{

    public class Monitor
    {
        public Monitor()
        {
            this.Computers = new HashSet<Computer>();
        }

        public byte Id { get; set; }
        public string Hersteller { get; set; }
        public string Produktbezeichnung { get; set; }
        public float Einkaufspreis { get; set; }
        public DateTime Einkaufsdatum { get; set; }

        public string Art { get; set; }
        public float Zoll { get; set; }
        public string Pixel { get; set; }

        public virtual ICollection<Computer> Computers { get; set; }
    }
}