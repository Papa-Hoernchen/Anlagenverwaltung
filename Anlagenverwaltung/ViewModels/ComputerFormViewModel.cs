using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Anlagenverwaltung.Models.HardwareKomponenten;

namespace Anlagenverwaltung.ViewModels
{
    public class ComputerFormViewModel
    {
        public IEnumerable<Arbeitsspeicher> Arbeitsspeichers { get; set; }
        public IEnumerable<Maus> Mauese { get; set; }
        public IEnumerable<Prozessor> Prozessoren { get; set; }
        public IEnumerable<Tastatur> Tastaturen { get; set; }

        public Computer Computer { get; set; }
    }
}