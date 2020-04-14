using System;
using Anlagenverwaltung.Models;
using Anlagenverwaltung.Models.HardwareKomponenten;
using Anlagenverwaltung.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Anlagenverwaltung.Models.SoftwareKomponenten;

namespace Anlagenverwaltung.Controllers
{
    public class ComputerController : Controller
    {
        private ApplicationDbContext _context;
        private HashSet<Festplatte> _festplatten;
        private HashSet<Monitor> _monitore;
        private HashSet<Anwendungssoftware> _anwendungsSoftware;
        private HashSet<Unterstuetzungssoftware> _unterstuetzungsSoftware;
        private const int computerKontoNr = 2;

        public ComputerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Computer
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
        public ViewResult New()
        {

            var viewModel = new ComputerFormViewModel()
            {
                Computer = new Computer() { KontoId = computerKontoNr },
                Arbeitsspeichers = _context.Arbeitsspeichers.ToList(),
                Mauese = _context.Maeuse.ToList(),
                Prozessoren = _context.Prozessoren.ToList(),
                Tastaturen = _context.Tastaturen.ToList(),
                Betriebssysteme = _context.Betriebssysteme.ToList(),
            };

            var allFestplattenList = _context.Festplatten.ToList();
            viewModel.Festplatten = allFestplattenList.Select(c => new SelectListItem
            {
                Text = c.Hersteller,
                Value = c.Id.ToString()
            });

            var allMonitorenList = _context.Monitore.ToList();
            viewModel.Monitore = allMonitorenList.Select(c => new SelectListItem
            {
                Text = c.Hersteller,
                Value = c.Id.ToString()
            });

            var allAnwendungsSoftwareList = _context.Anwendungssoftwares.ToList();
            viewModel.Anwendungssoftware = allAnwendungsSoftwareList.Select(c => new SelectListItem
            {
                Text = c.Hersteller + " " + c.Bezeichnung,
                Value = c.Id.ToString()
            });

            var allUnterstuetzungsSoftwareList = _context.Unterstuetzungssoftwares.ToList();
            viewModel.Unterstuetzungssoftware = allUnterstuetzungsSoftwareList.Select(c => new SelectListItem
            {
                Text = c.Hersteller + " " + c.Bezeichnung,
                Value = c.Id.ToString()
            });

            return View("ComputerForm", viewModel);
        }

        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        public ActionResult Edit(int id)
        {
            var computer = _context.Computers
                .Include(c => c.Festplatten)
                .Include(c=>c.Monitore)
                .Include(c=>c.Anwendungssoftware)
                .Include(c=>c.Unterstuetzungssoftware)
                .Include(c=> c.Konto)
                .First(i => i.Id == id);

            if (computer == null)
                return HttpNotFound();


            var viewModel = new ComputerFormViewModel()
            {
                Computer = computer,
                Arbeitsspeichers = _context.Arbeitsspeichers.ToList(),
                Mauese = _context.Maeuse.ToList(),
                Prozessoren = _context.Prozessoren.ToList(),
                Tastaturen = _context.Tastaturen.ToList(),
                Betriebssysteme = _context.Betriebssysteme.ToList()
            };

            var allFestplattenList = _context.Festplatten.ToList();
            viewModel.Festplatten = allFestplattenList.Select(c => new SelectListItem
            {
                Text = c.Hersteller + " " + c.Produktbezeichnung,
                Value = c.Id.ToString()
            });

            var allMonitorenList = _context.Monitore.ToList();
            viewModel.Monitore = allMonitorenList.Select(c => new SelectListItem
            {
                Text = c.Hersteller + " " + c.Produktbezeichnung,
                Value = c.Id.ToString()
            });

            var allAnwendungsSoftwareList = _context.Anwendungssoftwares.ToList();
            viewModel.Anwendungssoftware = allAnwendungsSoftwareList.Select(c => new SelectListItem
            {
                Text = c.Hersteller + " " + c.Bezeichnung,
                Value = c.Id.ToString()
            });

            var allUnterstuetzungsSoftwareList = _context.Unterstuetzungssoftwares.ToList();
            viewModel.Unterstuetzungssoftware = allUnterstuetzungsSoftwareList.Select(c => new SelectListItem
            {
                Text = c.Hersteller + " " + c.Bezeichnung,
                Value = c.Id.ToString()
            });


            return View("ComputerForm", viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ComputerFormViewModel editedViewModel)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new ComputerFormViewModel()
                {
                    Computer = editedViewModel.Computer,
                    Arbeitsspeichers = _context.Arbeitsspeichers.ToList(),
                    Mauese = _context.Maeuse.ToList(),
                    Prozessoren = _context.Prozessoren.ToList(),
                    Tastaturen = _context.Tastaturen.ToList(),
                    Betriebssysteme = _context.Betriebssysteme.ToList()
                };

                var allFestplattenList = _context.Festplatten.ToList();
                viewModel.Festplatten = allFestplattenList.Select(c => new SelectListItem
                {
                    Text = c.Hersteller,
                    Value = c.Id.ToString()
                });

                var allMonitorenList = _context.Monitore.ToList();
                viewModel.Monitore = allMonitorenList.Select(c => new SelectListItem
                {
                    Text = c.Hersteller,
                    Value = c.Id.ToString()
                });

                return View("ComputerForm", viewModel);
            }

            if (editedViewModel.Computer.Id == 0)
            {
                editedViewModel.Computer.Festplatten = GetFestplattenFromIDs(editedViewModel.SelectedFestplatten);
                editedViewModel.Computer.Monitore = GetMonitoreFromIDs(editedViewModel.SelectedMonitore);
                editedViewModel.Computer.Anwendungssoftware =
                    GetAnwendungssoftwareFromIDs(editedViewModel.SelectedAnwendungsSoftware);
                editedViewModel.Computer.Unterstuetzungssoftware =
                    GetUnterstuetzungsSoftwareFromIDs(editedViewModel.SelectedUnterstuetzungsSoftware);
                editedViewModel.Computer.Id = GetNewComputerId(_context.Computers.ToList());
                editedViewModel.Computer.KontoId = computerKontoNr;
                _context.Computers.Add(editedViewModel.Computer);
            }
                
            else
            {
                var computerInDb = _context.Computers.Single(c => c.Id == editedViewModel.Computer.Id);

                computerInDb.Hersteller = editedViewModel.Computer.Hersteller;
                computerInDb.MacAdresse = editedViewModel.Computer.MacAdresse;
                computerInDb.Einkaufspreis = editedViewModel.Computer.Einkaufspreis;
                computerInDb.Einkaufsdatum = editedViewModel.Computer.Einkaufsdatum;
                computerInDb.ArbeitsspeicherId = editedViewModel.Computer.ArbeitsspeicherId;
                computerInDb.MausId = editedViewModel.Computer.MausId;
                computerInDb.ProzessorId = editedViewModel.Computer.ProzessorId;
                computerInDb.TastaturId = editedViewModel.Computer.TastaturId;
                computerInDb.KontoId = computerKontoNr;
                if (computerInDb.FestplattenIds != editedViewModel.SelectedFestplatten)
                    computerInDb.Festplatten = GetFestplattenFromIDs(editedViewModel.SelectedFestplatten);
                if (computerInDb.MonitorenIds != editedViewModel.SelectedMonitore)
                    computerInDb.Monitore = GetMonitoreFromIDs(editedViewModel.SelectedMonitore);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Computer");
        }

        private HashSet<Festplatte> GetFestplattenFromIDs(List<int> festplattenIds)
        {
            _festplatten = new HashSet<Festplatte>();
            for (int i = 0; i < festplattenIds.Count; i++)
            {
                var festplattenId =  festplattenIds[i];
                _festplatten.Add(_context.Festplatten.SingleOrDefault(c => c.Id == festplattenId));
            }

            return _festplatten;
        }

        private HashSet<Monitor> GetMonitoreFromIDs(List<int> monitorIds)
        {
            _monitore = new HashSet<Monitor>();
            for (int i = 0; i < monitorIds.Count; i++)
            {
                var monitorenId = monitorIds[i];
                _monitore.Add(_context.Monitore.SingleOrDefault(c => c.Id == monitorenId));
            }

            return _monitore;
        }

        private HashSet<Anwendungssoftware> GetAnwendungssoftwareFromIDs(List<int> aSoftwareIds)
        {
            _anwendungsSoftware = new HashSet<Anwendungssoftware>();
            for (int i = 0; i < aSoftwareIds.Count; i++)
            {
                var aSoftwareId = aSoftwareIds[i];
                _anwendungsSoftware.Add(_context.Anwendungssoftwares.SingleOrDefault(c => c.Id == aSoftwareId));
            }

            return _anwendungsSoftware;
        }

        private HashSet<Unterstuetzungssoftware> GetUnterstuetzungsSoftwareFromIDs(List<int> unterstuetzungsSoftwareIds)
        {
            _unterstuetzungsSoftware = new HashSet<Unterstuetzungssoftware>();
            for (int i = 0; i < unterstuetzungsSoftwareIds.Count; i++)
            {
                var unterstuetzungsSoftwareId = unterstuetzungsSoftwareIds[i];
                _unterstuetzungsSoftware.Add(_context.Unterstuetzungssoftwares.SingleOrDefault(c => c.Id == unterstuetzungsSoftwareId));
            }

            return _unterstuetzungsSoftware;
        }

        private int GetNewComputerId(List<Computer> computers)
        {
            if (computers.Count > 0)
            {
                var computerId = computers[computers.Count - 1].Id;
                computerId += 1;
                return computerId;
            }
            else
            {
                return 1;
            }
        }

    }
}