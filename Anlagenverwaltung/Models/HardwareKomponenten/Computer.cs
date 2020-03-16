using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anlagenverwaltung.Models.HardwareKomponenten
{
    public class Computer : Hardware
    {
        public Computer()
        {
            this.Festplatten = new HashSet<Festplatte>();
            this.Monitore = new HashSet<Monitor>();
        }

        public Arbeitsspeicher Arbeitsspeicher { get; set; }
        public byte ArbeitsspeicherId { get; set; }

        public Prozessor Prozessor { get; set; }
        public byte ProzessorId { get; set; }

        public Maus Maus { get; set; }
        public byte MausId { get; set; }

        public Tastatur Tastatur { get; set; }
        public byte TastaturId { get; set; }

        public virtual ICollection<Festplatte> Festplatten { get; set; }
        public virtual ICollection<Monitor> Monitore { get; set; }

    }
}