using System.Collections.Generic;
using Anlagenverwaltung.Models;
using Anlagenverwaltung.Models.HardwareKomponenten;
using System.Linq;
using System.Web.Mvc;

namespace Anlagenverwaltung.Controllers
{
    public class ArbeitsspeicherController : Controller
    {
        private ApplicationDbContext _context;

        public ArbeitsspeicherController()
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
            var arbeitsspeicher = new Arbeitsspeicher();
            return View("ArbeitsspeicherForm", arbeitsspeicher);
        }

        // GET: Arbeitsspeicher
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
            var arbeitsspeicher = _context.Arbeitsspeichers.SingleOrDefault(a => a.Id == id);

            if (arbeitsspeicher == null)
                return HttpNotFound();

            return View("ArbeitsspeicherForm", arbeitsspeicher);
        }

        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Arbeitsspeicher arbeitsspeicher)
        {

            if (!ModelState.IsValid)
            {
                return View("ArbeitsspeicherForm", arbeitsspeicher);
            }

            if (arbeitsspeicher.Id == 0)
            {
                arbeitsspeicher.Id = GetNewArbeitsspeicherId(_context.Arbeitsspeichers.ToList());
                _context.Arbeitsspeichers.Add(arbeitsspeicher);
            }
                
            else
            {
                var arbeitsspeicherinDto = _context.Arbeitsspeichers.Single(a => a.Id == arbeitsspeicher.Id);

                arbeitsspeicherinDto.Hersteller = arbeitsspeicher.Hersteller;
                arbeitsspeicherinDto.Produktbezeichnung = arbeitsspeicher.Produktbezeichnung;
                arbeitsspeicherinDto.Einkaufspreis = arbeitsspeicher.Einkaufspreis;
                arbeitsspeicherinDto.Einkaufsdatum = arbeitsspeicher.Einkaufsdatum;
                arbeitsspeicherinDto.Speicherkapazitaet = arbeitsspeicher.Speicherkapazitaet;
                arbeitsspeicherinDto.Taktfrequenz = arbeitsspeicher.Taktfrequenz;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Arbeitsspeicher");
        }

        private byte GetNewArbeitsspeicherId(List<Arbeitsspeicher> arbeitsspeichers)
        {
            if (arbeitsspeichers.Count > 0)
            {
                var arbeitsspeicherID = arbeitsspeichers[arbeitsspeichers.Count - 1].Id;
                arbeitsspeicherID += 1;
                return arbeitsspeicherID;
            }
            else
            {
                return 1;
            }
        }
    }
}