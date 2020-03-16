using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anlagenverwaltung.Dto.HardwareKomponentenDto
{
    public class ProzessorDto : HardwareDto
    {
        public int Kerne { get; set; }
        public float Taktfrequenz { get; set; }
        public float Uebertragungsrate { get; set; }
    }
}