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
    public class BetriebssystemController : Controller
    {
        private ApplicationDbContext _context;
        private const int softwareKontoNr = 3;

        public BetriebssystemController()
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
            var betriebssystem = new Betriebssystem(){KontoId = softwareKontoNr};
            return View("BetriebssystemForm", betriebssystem);
        }

        // GET: Betriebssystem
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
            var betriebssystem = _context.Betriebssysteme
                .Include(c=>c.Konto)
                .SingleOrDefault(a => a.Id == id);

            if (betriebssystem == null)
                return HttpNotFound();

            return View("BetriebssystemForm", betriebssystem);
        }

        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Betriebssystem betriebssystem)
        {

            if (!ModelState.IsValid)
            {
                return View("BetriebssystemForm", betriebssystem);
            }

            if (betriebssystem.Id == 0)
            {
                betriebssystem.Id = GetNewBetriebssystemId(_context.Betriebssysteme.ToList());
                betriebssystem.KontoId = softwareKontoNr;
                _context.Betriebssysteme.Add(betriebssystem);
            }

            else
            {
                var betriebssystemInDto = _context.Betriebssysteme.Single(a => a.Id == betriebssystem.Id);

                betriebssystemInDto.Hersteller = betriebssystem.Hersteller;
                betriebssystemInDto.Bezeichnung = betriebssystem.Bezeichnung;
                betriebssystemInDto.Einkaufspreis = betriebssystem.Einkaufspreis;
                betriebssystemInDto.Einkaufsdatum = betriebssystem.Einkaufsdatum;
                betriebssystemInDto.Art = betriebssystem.Art;
                betriebssystemInDto.Lizenznummer = betriebssystem.Lizenznummer;
                betriebssystemInDto.KontoId = softwareKontoNr;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Betriebssystem");
        }

        private int GetNewBetriebssystemId(List<Betriebssystem> betriebssysteme)
        {
            if (betriebssysteme.Count > 0)
            {
                var betriebssystemId = betriebssysteme[betriebssysteme.Count - 1].Id;
                betriebssystemId += 1;
                return betriebssystemId;
            }
            else
            {
                return 1;
            }
        }


    }
}