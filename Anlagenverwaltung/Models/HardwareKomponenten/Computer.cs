using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anlagenverwaltung.Models.HardwareKomponenten
{
    public class Computer : Hardware
    {
        public Arbeitsspeicher Arbeitsspeicher { get; set; }
        public byte ArbeitsspeicherId { get; set; }

        public Prozessor Prozessor { get; set; }
        public byte ProzessorId { get; set; }

        public Festplatte Festplatte { get; set; }
        public byte FestplatteId { get; set; }

        public Maus Maus { get; set; }
        public byte MausId { get; set; }

        public Monitor Monitor { get; set; }
        public byte MonitorId { get; set; }

        public Tastatur Tastatur { get; set; }
        public byte TastaturId { get; set; }

    }
}