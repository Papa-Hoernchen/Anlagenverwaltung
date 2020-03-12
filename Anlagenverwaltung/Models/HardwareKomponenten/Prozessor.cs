using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anlagenverwaltung.Models.HardwareKomponenten
{
    public class Prozessor : Hardware
    {
        public int Kerne { get; set; }
        public float Taktfrequenz { get; set; }
        public float Uebertragungsrate { get; set; }

    }
}