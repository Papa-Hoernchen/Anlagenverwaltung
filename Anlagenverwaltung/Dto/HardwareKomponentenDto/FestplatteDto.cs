using System;
using System.Collections.Generic;

namespace Anlagenverwaltung.Dto.HardwareKomponentenDto
{
    public class FestplatteDto
    {
        public int Id { get; set; }
        public string Hersteller { get; set; }
        public string Produktbezeichnung { get; set; }
        public float Einkaufspreis { get; set; }
        public DateTime Einkaufsdatum { get; set; }

        public string Art { get; set; }
        public int Speicherkapazitaet { get; set; }
        public string Schnittstelle { get; set; }
    }
}