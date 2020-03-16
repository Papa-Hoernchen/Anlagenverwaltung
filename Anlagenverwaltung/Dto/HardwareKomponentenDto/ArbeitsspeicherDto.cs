using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anlagenverwaltung.Dto.HardwareKomponentenDto
{
    public class ArbeitsspeicherDto : HardwareDto
    {
        public int Speicherkapazitaet { get; set; }
        public float Taktfrequenz { get; set; }
        public float Datenuebrtragungsrate { get; set; }
    }
}