using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Anlagenverwaltung.Models.SoftwareKomponenten;

namespace Anlagenverwaltung.Controllers
{
    public class SoftwareController : Controller
    {
        // GET: Software
        public ActionResult Index()
        {
            var anwendungssoftware = new Anwendungssoftware()
            {
                Aufgabe = "Betriebssystem",
                Einkaufsdatum = DateTime.Parse("2019-05-05"),
                Einkaufspreis = 100.00,
                Hersteller = "Windows",
                Id = 1,
                Lizenznummer = "xyz",
                Name = "Windows",
                Version = "10"
            };
            return View(anwendungssoftware);
        }
    }
}