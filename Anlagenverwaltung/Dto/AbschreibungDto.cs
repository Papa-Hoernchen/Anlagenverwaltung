using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anlagenverwaltung.Dto
{
    public class AbschreibungDto
    {
        public int Id { get; set; }
        public int KontoNr { get; set; }
        public string Name { get; set; }
        public DateTime Anschaffungsdatum { get; set; }
        public float Anschaffungskosten { get; set; }
        public int Nutzungsdauer { get; set; }
        public float AfaProzent { get; set; }
        public float BuchwertBegin { get; set; }
        public float BuchwertEnde { get; set; }
        public float Abschreibungssatz { get; set; }
    }
}