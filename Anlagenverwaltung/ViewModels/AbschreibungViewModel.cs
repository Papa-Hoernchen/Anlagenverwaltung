using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Anlagenverwaltung.Models;

namespace Anlagenverwaltung.ViewModels
{
    public class AbschreibungViewModel
    {
        public IEnumerable<Abschreibung> Abschreibungen { get; set; }
        public int SelectedYear { get; set; }
    }
}