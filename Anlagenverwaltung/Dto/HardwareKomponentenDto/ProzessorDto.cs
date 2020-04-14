using System;

namespace Anlagenverwaltung.Dto.HardwareKomponentenDto
{
    public class ProzessorDto
    {
        public byte Id { get; set; }
        public string Hersteller { get; set; }
        public string Produktbezeichnung { get; set; }
        public float Einkaufspreis { get; set; }
        public DateTime Einkaufsdatum { get; set; }
        public int Kerne { get; set; }
        public float Taktfrequenz { get; set; }
    }
}