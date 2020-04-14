using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anlagenverwaltung.Dto
{
    public class BenutzerDto
    {
        public int Id { get; set; }
        public int PersonalNr { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }
    }
}