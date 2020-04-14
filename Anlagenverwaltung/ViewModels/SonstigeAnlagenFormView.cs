using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Anlagenverwaltung.Models;

namespace Anlagenverwaltung.ViewModels
{
    public class SonstigeAnlagenFormView
    {
        public IEnumerable<Konto> Konten { get; set; }
        public SonstigeAnlage SonstigeAnlage { get; set; }
    }
}