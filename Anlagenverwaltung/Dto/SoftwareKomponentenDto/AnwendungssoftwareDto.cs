using System;
using System.Collections.Generic;
using Anlagenverwaltung.Dto.HardwareKomponentenDto;

namespace Anlagenverwaltung.Dto.SoftwareKomponentenDto
{
    public class AnwendungssoftwareDto
    {
        public int Id { get; set; }

        public string Art { get; set; }
        public string Hersteller { get; set; }
        public string Bezeichnung { get; set; }
        public string Lizenznummer { get; set; }
        public float Einkaufspreis { get; set; }
        public DateTime Einkaufsdatum { get; set; }

        public KontoDto Konto { get; set; }
        public int? KontoId { get; set; }
    }
}