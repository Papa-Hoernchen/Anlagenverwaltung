﻿using System;

namespace Anlagenverwaltung.Dto.HardwareKomponentenDto
{
    public class MausDto
    {
        public byte Id { get; set; }
        public string Hersteller { get; set; }
        public string Produktbezeichnung { get; set; }
        public float Einkaufspreis { get; set; }
        public DateTime Einkaufsdatum { get; set; }
        public string Art { get; set; }
    }
}