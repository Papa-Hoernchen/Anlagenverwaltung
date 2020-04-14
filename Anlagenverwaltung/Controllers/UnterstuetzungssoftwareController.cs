using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Anlagenverwaltung.Models;
using Anlagenverwaltung.Models.SoftwareKomponenten;

namespace Anlagenverwaltung.Controllers
{
    public class UnterstuetzungssoftwareController : Controller
    {
        private ApplicationDbContext _context;
        private const int softwareKontoNr = 3;

        public UnterstuetzungssoftwareController()
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
            var unterstuetzungssoftware = new Unterstuetzungssoftware(){KontoId = softwareKontoNr};
            return View("UnterstuetzungssoftwareForm", unterstuetzungssoftware);
        }

        // GET: Unterstuetzungssoftware
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
            var unterstuetzungssoftware = _context.Unterstuetzungssoftwares
                .Include(c=>c.Konto)
                .SingleOrDefault(a => a.Id == id);

            if (unterstuetzungssoftware == null)
                return HttpNotFound();

            return View("UnterstuetzungssoftwareForm", unterstuetzungssoftware);
        }

        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Unterstuetzungssoftware unterstuetzungssoftware)
        {

            if (!ModelState.IsValid)
            {
                return View("UnterstuetzungssoftwareForm", unterstuetzungssoftware);
            }

            if (unterstuetzungssoftware.Id == 0)
            {
                unterstuetzungssoftware.Id = GetNewUnterstuetzungssoftwareId(_context.Unterstuetzungssoftwares.ToList());
                unterstuetzungssoftware.KontoId = softwareKontoNr;
                _context.Unterstuetzungssoftwares.Add(unterstuetzungssoftware);
            }

            else
            {
                var unterstuetzungssoftwareInDto = _context.Unterstuetzungssoftwares.Single(a => a.Id == unterstuetzungssoftware.Id);

                unterstuetzungssoftwareInDto.Hersteller = unterstuetzungssoftware.Hersteller;
                unterstuetzungssoftwareInDto.Bezeichnung = unterstuetzungssoftware.Bezeichnung;
                unterstuetzungssoftwareInDto.Einkaufspreis = unterstuetzungssoftware.Einkaufspreis;
                unterstuetzungssoftwareInDto.Einkaufsdatum = unterstuetzungssoftware.Einkaufsdatum;
                unterstuetzungssoftwareInDto.Art = unterstuetzungssoftware.Art;
                unterstuetzungssoftwareInDto.Lizenznummer = unterstuetzungssoftware.Lizenznummer;
                unterstuetzungssoftwareInDto.KontoId = softwareKontoNr;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Unterstuetzungssoftware");
        }

        private int GetNewUnterstuetzungssoftwareId(List<Unterstuetzungssoftware> unterstuetzungssoftware)
        {
            if (unterstuetzungssoftware.Count > 0)
            {
                var unterstuetzungssoftwareId = unterstuetzungssoftware[unterstuetzungssoftware.Count - 1].Id;
                unterstuetzungssoftwareId += 1;
                return unterstuetzungssoftwareId;
            }
            else
            {
                return 1;
            }
        }
    }
}