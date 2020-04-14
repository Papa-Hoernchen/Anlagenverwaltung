using System.Collections.Generic;
using Anlagenverwaltung.Models;
using Anlagenverwaltung.Models.HardwareKomponenten;
using System.Linq;
using System.Web.Mvc;

namespace Anlagenverwaltung.Controllers
{
    public class ProzessorController : Controller
    {
        private ApplicationDbContext _context;

        public ProzessorController()
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
            var prozessor = new Prozessor();
            return View("ProzessorForm", prozessor);
        }

        // GET: Prozessor
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
            var prozessor = _context.Prozessoren.SingleOrDefault(a => a.Id == id);

            if (prozessor == null)
                return HttpNotFound();

            return View("ProzessorForm", prozessor);
        }

        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Prozessor prozessor)
        {

            if (!ModelState.IsValid)
            {
                return View("ProzessorForm", prozessor);
            }

            if (prozessor.Id == 0)
            {
                prozessor.Id = GetNewProzessorId(_context.Prozessoren.ToList());
                _context.Prozessoren.Add(prozessor);
            }
            else
            {
                var prozessorinDto = _context.Prozessoren.Single(a => a.Id == prozessor.Id);

                prozessorinDto.Hersteller = prozessor.Hersteller;
                prozessorinDto.Produktbezeichnung = prozessor.Produktbezeichnung;
                prozessorinDto.Einkaufspreis = prozessor.Einkaufspreis;
                prozessorinDto.Einkaufsdatum = prozessor.Einkaufsdatum;
                prozessorinDto.Kerne = prozessor.Kerne;
                prozessorinDto.Taktfrequenz = prozessor.Taktfrequenz;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Prozessor");
        }

        private byte GetNewProzessorId(List<Prozessor> prozessoren)
        {
            if (prozessoren.Count > 0)
            {
                var prozessorId = prozessoren[prozessoren.Count - 1].Id;
                prozessorId += 1;
                return prozessorId;
            }
            else
            {
                return 1;
            }
        }
    }
}