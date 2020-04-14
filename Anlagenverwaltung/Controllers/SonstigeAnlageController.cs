using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Anlagenverwaltung.Models;
using Anlagenverwaltung.Models.SoftwareKomponenten;
using Anlagenverwaltung.ViewModels;

namespace Anlagenverwaltung.Controllers
{
    public class SonstigeAnlageController : Controller
    {
        private ApplicationDbContext _context;

        public SonstigeAnlageController()
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
            var viewModel = new SonstigeAnlagenFormView()
            {
                SonstigeAnlage = new SonstigeAnlage(),
                Konten = _context.Konten.ToList()
            };
            return View("SonstigeAnlageForm", viewModel);
        }

        // GET: SonstigeAnlage
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
            var sonstigeAnlage = _context.SonstigeAnlagen
                .Include(c=> c.Konto)
                .SingleOrDefault(a => a.Id == id);

            if (sonstigeAnlage == null)
                return HttpNotFound();

            var viewModel = new SonstigeAnlagenFormView()
            {
                SonstigeAnlage = sonstigeAnlage,
                Konten = _context.Konten.ToList()
            };

            return View("SonstigeAnlageForm", viewModel);
        }

        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(SonstigeAnlage sonstigeAnlage)
        {

            if (!ModelState.IsValid)
            {
                return View("SonstigeAnlageForm", sonstigeAnlage);
            }

            if (sonstigeAnlage.Id == 0)
            {
                sonstigeAnlage.Id = GetNewSonstigeAnlageId(_context.SonstigeAnlagen.ToList());
                _context.SonstigeAnlagen.Add(sonstigeAnlage);
            }

            else
            {
                var sonstigeAnlageInDto = _context.SonstigeAnlagen.Single(a => a.Id == sonstigeAnlage.Id);

                sonstigeAnlageInDto.Gegenstand = sonstigeAnlage.Gegenstand;
                sonstigeAnlageInDto.Bezeichnung = sonstigeAnlage.Bezeichnung;
                sonstigeAnlageInDto.Einkaufspreis = sonstigeAnlage.Einkaufspreis;
                sonstigeAnlageInDto.Einkaufsdatum = sonstigeAnlage.Einkaufsdatum;
                sonstigeAnlageInDto.KontoId = sonstigeAnlage.KontoId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "SonstigeAnlage");
        }

        private int GetNewSonstigeAnlageId(List<SonstigeAnlage> sonstigeAnlage)
        {
            if (sonstigeAnlage.Count > 0)
            {
                var sonstigeAnlageId = sonstigeAnlage[sonstigeAnlage.Count - 1].Id;
                sonstigeAnlageId += 1;
                return sonstigeAnlageId;
            }
            else
            {
                return 1;
            }
        }
    }
}