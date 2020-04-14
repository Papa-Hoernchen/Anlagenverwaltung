using System.Collections.Generic;
using Anlagenverwaltung.Models;
using Anlagenverwaltung.Models.HardwareKomponenten;
using System.Linq;
using System.Web.Mvc;

namespace Anlagenverwaltung.Controllers
{
    public class TastaturController : Controller
    {
        private ApplicationDbContext _context;

        public TastaturController()
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
            var tastatur = new Tastatur();
            return View("TastaturForm", tastatur);
        }

        // GET: Tastatur
        public ActionResult Index()
        {
            if (User.IsInRole(RoleNames.Admin) || User.IsInRole(RoleNames.CanUseVerwaltung))
            {
                return View();
            }

            return View("ReadOnlyIndex");
        }

        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        public ActionResult Edit(int id)
        {
            var tastatur = _context.Tastaturen.SingleOrDefault(a => a.Id == id);

            if (tastatur == null)
                return HttpNotFound();

            return View("TastaturForm", tastatur);
        }

        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Tastatur tastatur)
        {

            if (!ModelState.IsValid)
            {
                return View("TastaturForm", tastatur);
            }

            if (tastatur.Id == 0)
            {
                tastatur.Id = GetNewTastaturId(_context.Tastaturen.ToList());
                _context.Tastaturen.Add(tastatur);
            }
            else
            {
                var tastaturinDto = _context.Tastaturen.Single(a => a.Id == tastatur.Id);

                tastaturinDto.Hersteller = tastatur.Hersteller;
                tastaturinDto.Produktbezeichnung = tastatur.Produktbezeichnung;
                tastaturinDto.Einkaufspreis = tastatur.Einkaufspreis;
                tastaturinDto.Einkaufsdatum = tastatur.Einkaufsdatum;
                tastaturinDto.Art = tastatur.Art;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Tastatur");
        }

        private byte GetNewTastaturId(List<Tastatur> tastatur)
        {
            if (tastatur.Count > 0)
            {
                var tastaturId = tastatur[tastatur.Count - 1].Id;
                tastaturId += 1;
                return tastaturId;
            }
            else
            {
                return 1;
            }
        }
    }
}