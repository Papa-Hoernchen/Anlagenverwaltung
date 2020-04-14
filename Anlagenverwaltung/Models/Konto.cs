using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Anlagenverwaltung.Models
{
    public class Konto
    {
        public int Id { get; set; }
        public int Nummer { get; set; }
        public string Bezeichnung { get; set; }

        [NotMapped]
        public string NummerBezeichnung
        {
            get { return Nummer.ToString() + " " + Bezeichnung; }
        }
    }
}