using System.Collections.Generic;
using Anlagenverwaltung.Models;
using Anlagenverwaltung.Models.HardwareKomponenten;
using System.Linq;
using System.Web.Mvc;

namespace Anlagenverwaltung.Controllers
{
    public class MonitorController : Controller
    {
        private ApplicationDbContext _context;

        public MonitorController()
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
            var monitor = new Monitor();
            return View("MonitorForm", monitor);
        }

        // GET:  Monitor
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
            var monitor = _context.Monitore.SingleOrDefault(a => a.Id == id);

            if (monitor == null)
                return HttpNotFound();

            return View("MonitorForm", monitor);
        }

        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Monitor monitor)
        {

            if (!ModelState.IsValid)
            {
                return View("MonitorForm", monitor);
            }

            if (monitor.Id == 0)
            {
                monitor.Id = GetNewMonitorId(_context.Monitore.ToList());
                _context.Monitore.Add(monitor);
            }
            else
            {
                var monitorInDto = _context.Monitore.Single(a => a.Id == monitor.Id);

                monitorInDto.Hersteller = monitor.Hersteller;
                monitorInDto.Produktbezeichnung = monitor.Produktbezeichnung;
                monitorInDto.Einkaufspreis = monitor.Einkaufspreis;
                monitorInDto.Einkaufsdatum = monitor.Einkaufsdatum;
                monitorInDto.Art = monitor.Art;
                monitorInDto.Zoll = monitor.Zoll;
                monitorInDto.Pixel = monitor.Pixel;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Monitor");
        }

        private int GetNewMonitorId(List<Monitor> monitore)
        {
            if (monitore.Count > 0)
            {
                var monitorID = monitore[monitore.Count - 1].Id;
                monitorID += 1;
                return monitorID;
            }
            else
            {
                return 1;
            }
        }
    }
}