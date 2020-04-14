using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Anlagenverwaltung.Models;
using Anlagenverwaltung.Models.SoftwareKomponenten;

namespace Anlagenverwaltung.Controllers
{
    public class AnwendungssoftwareController : Controller
    {
        private ApplicationDbContext _context;
        private const int softwareKontoNr = 3;

        public AnwendungssoftwareController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        public ViewResult New()
        {
            var anwendungssoftware = new Anwendungssoftware(){KontoId = softwareKontoNr };
            return View("AnwendungssoftwareForm", anwendungssoftware);
        }

        // GET: Anwendungssoftware
        public ActionResult Index()
        {
            if (User.IsInRole(RoleNames.Admin))
            {
                return View();
            }
            if (User.IsInRole(RoleNames.CanUseVerwaltung))
            {
                return View("VerwaltungIndex");
            }


            return View("ReadOnlyIndex");

        }

        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        public ActionResult Edit(int id)
        {
            var anwendungssoftware = _context.Anwendungssoftwares
                .Include(c => c.Konto)
                .SingleOrDefault(a => a.Id == id);

            if (anwendungssoftware == null)
                return HttpNotFound();

            return View("AnwendungssoftwareForm", anwendungssoftware);
        }

        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Anwendungssoftware anwendungssoftware)
        {

            if (!ModelState.IsValid)
            {
                return View("AnwendungssoftwareForm", anwendungssoftware);
            }

            if (anwendungssoftware.Id == 0)
            {
                anwendungssoftware.Id = GetNewAnwendungssoftwareId(_context.Anwendungssoftwares.ToList());
                anwendungssoftware.KontoId = softwareKontoNr;
                _context.Anwendungssoftwares.Add(anwendungssoftware);
            }

            else
            {
                var anwendungssoftwareInDto = _context.Anwendungssoftwares.Single(a => a.Id == anwendungssoftware.Id);

                anwendungssoftwareInDto.Hersteller = anwendungssoftware.Hersteller;
                anwendungssoftwareInDto.Bezeichnung = anwendungssoftware.Bezeichnung;
                anwendungssoftwareInDto.Einkaufspreis = anwendungssoftware.Einkaufspreis;
                anwendungssoftwareInDto.Einkaufsdatum = anwendungssoftware.Einkaufsdatum;
                anwendungssoftwareInDto.Art = anwendungssoftware.Art;
                anwendungssoftwareInDto.Lizenznummer = anwendungssoftware.Lizenznummer;
                anwendungssoftwareInDto.KontoId = softwareKontoNr;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Anwendungssoftware");
        }

        private int GetNewAnwendungssoftwareId(List<Anwendungssoftware> anwendungssoftware)
        {
            if (anwendungssoftware.Count > 0)
            {
                var anwendungssoftwareId = anwendungssoftware[anwendungssoftware.Count - 1].Id;
                anwendungssoftwareId += 1;
                return anwendungssoftwareId;
            }
            else
            {
                return 1;
            }
        }
    }
}