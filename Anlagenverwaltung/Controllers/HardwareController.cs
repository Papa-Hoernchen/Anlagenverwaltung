using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Anlagenverwaltung.Models.HardwareKomponenten;

namespace Anlagenverwaltung.Controllers
{
    public class HardwareController : Controller
    {
        // GET: Hardware
        public ActionResult Index()
        {
            var maus = new Maus()
            {
                Art = "Lasermaus",
                Einkaufsdatum = DateTime.Parse("2019-02-02"),
                Einkaufspreis = 50.00,
                Id = 1,
                Modellnummer = "abcxyz",
                Produktname = "Super Maus",
                Produktnummer = "123-ab",
                Seriennummer = "cbg-156"
            };

            return View(maus);
        }
    }
}