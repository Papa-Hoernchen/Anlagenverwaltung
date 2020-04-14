using System.Collections.Generic;
using Anlagenverwaltung.Models;
using Anlagenverwaltung.Models.HardwareKomponenten;
using System.Linq;
using System.Web.Mvc;

namespace Anlagenverwaltung.Controllers
{
    public class FestplatteController : Controller
    {
        private ApplicationDbContext _context;

        public FestplatteController()
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
            var festplatte = new Festplatte();
            return View("FestplatteForm", festplatte);
        }

        // GET: Festplatte
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
            var festplatte = _context.Festplatten.SingleOrDefault(f => f.Id == id);

            if (festplatte == null)
                return HttpNotFound();

            return View("FestplatteForm", festplatte);
        }

        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Festplatte festplatte)
        {

            if (!ModelState.IsValid)
            {
                return View("FestplatteForm", festplatte);
            }

            if (festplatte.Id == 0)
            {
                festplatte.Id = GetNewFestplattenId(_context.Festplatten.ToList());
                _context.Festplatten.Add(festplatte);
            }

            else
            {
                var festplatteinDto = _context.Festplatten.Single(a => a.Id == festplatte.Id);

                festplatteinDto.Hersteller = festplatte.Hersteller;
                festplatteinDto.Produktbezeichnung = festplatte.Produktbezeichnung;
                festplatteinDto.Einkaufspreis = festplatte.Einkaufspreis;
                festplatteinDto.Einkaufsdatum = festplatte.Einkaufsdatum;
                festplatteinDto.Art = festplatte.Art;
                festplatteinDto.Speicherkapazitaet = festplatte.Speicherkapazitaet;
                festplatteinDto.Schnittstelle = festplatte.Schnittstelle;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Festplatte");
        }

        private int GetNewFestplattenId(List<Festplatte> festplatten)
        {
            if (festplatten.Count > 0)
            {
                var festplattenID = festplatten[festplatten.Count - 1].Id;
                festplattenID += 1;
                return festplattenID;
            }
            else
            {
                return 1;
            }
        }
    }
}