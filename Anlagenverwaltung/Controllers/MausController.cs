using System.Collections.Generic;
using Anlagenverwaltung.Models;
using Anlagenverwaltung.Models.HardwareKomponenten;
using System.Linq;
using System.Web.Mvc;

namespace Anlagenverwaltung.Controllers
{
    public class MausController : Controller
    {
        private ApplicationDbContext _context;

        public MausController()
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
            var maus = new Maus();
            return View("MausForm", maus);
        }

        // GET: Maus
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
            var maus = _context.Maeuse.SingleOrDefault(a => a.Id == id);

            if (maus == null)
                return HttpNotFound();

            return View("MausForm", maus);
        }

        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Maus maus)
        {

            if (!ModelState.IsValid)
            {
                return View("MausForm", maus);
            }

            if (maus.Id == 0)
            {
                maus.Id = GetNewMausId(_context.Maeuse.ToList());
                _context.Maeuse.Add(maus);
            }
                
            else
            {
                var mausInDto = _context.Maeuse.Single(a => a.Id == maus.Id);

                mausInDto.Hersteller = maus.Hersteller;
                mausInDto.Produktbezeichnung = maus.Produktbezeichnung;
                mausInDto.Einkaufspreis = maus.Einkaufspreis;
                mausInDto.Einkaufsdatum = maus.Einkaufsdatum;
                mausInDto.Art = maus.Art;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Maus");
        }

        private byte GetNewMausId(List<Maus> maeuse)
        {
            if (maeuse.Count > 0)
            {
                var mausId = maeuse[maeuse.Count - 1].Id;
                mausId += 1;
                return mausId;
            }
            else
            {
                return 1;
            }
        }
    }
}