using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Anlagenverwaltung.Models;
using Anlagenverwaltung.ViewModels;

namespace Anlagenverwaltung.Controllers
{
    public class AbschreibungController : Controller
    {
        private ApplicationDbContext _context;
        private KontoManager _kontoManager;
        private const int nutzungsdauerSoftware = 3;
        private const int nutzungsdauerComputer = 3;

        public AbschreibungController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }


        // GET: AbschreibungSoftware
        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult IndexSoftware()
        {
            var viewModel = new AbschreibungViewModel()
            {
                Abschreibungen = _context.Abschreibungen.ToList(),
                SelectedYear = DateTime.Now.Year
            };
            return View(viewModel);
        }

        // GET: AbschreibungGeschäfsausstattung
        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult IndexGeschaeftsausstattung()
        {
            return View();
        }

        // GET: AbschreibungBueroeinrichtung
        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult IndexBueroeinrichtung()
        {
            return View();
        }

        // GET: AbschreibungPKW
        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult IndexPKW()
        {
            return View();
        }

        // GET: AnteilAO
        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult IndexAnteilAO()
        {
            return View();
        }

        // GET: Gesamt
        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult IndexGesamt()
        {
            return View();
        }

        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult UebergabeBetriebssystem()
        {
            var betriebssysteme = _context.Betriebssysteme.ToList();
            var softwareAbschreibungen = _context.Abschreibungen.ToList();
            _kontoManager = new KontoManager();
            var lastKontoNr = _kontoManager.GetNewDetailedKontoNr(_context, _kontoManager.KontoNrSoftware) - 1;

            foreach (var betriebssystem in betriebssysteme)
            {
                var betriebssystemeInAbschreibung = softwareAbschreibungen
                    .Where(c => c.Name.Equals(betriebssystem.Hersteller + " " + betriebssystem.Bezeichnung)).ToList();

                if (betriebssystemeInAbschreibung.Count == 0)
                {
                    lastKontoNr += 1;
                    var neueAbschreibungsAnlage = new Abschreibung()
                    {
                        Anschaffungsdatum = betriebssystem.Einkaufsdatum,
                        Anschaffungskosten = betriebssystem.Einkaufspreis,
                        KontoNr = lastKontoNr,
                        Name = betriebssystem.Hersteller + " " + betriebssystem.Bezeichnung,
                        Nutzungsdauer = nutzungsdauerSoftware
                    };
                    _context.Abschreibungen.Add(neueAbschreibungsAnlage);
                }
                else
                {
                    betriebssystemeInAbschreibung[0].Anschaffungsdatum = betriebssystem.Einkaufsdatum;
                    betriebssystemeInAbschreibung[0].Anschaffungskosten = betriebssystem.Einkaufspreis;
                    betriebssystemeInAbschreibung[0].Nutzungsdauer = nutzungsdauerSoftware;
                }
            }

            _context.SaveChanges();
            return RedirectToAction("IndexSoftware", "Abschreibung");
        }

        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult UebergabeAnwendungssoftware()
        {
            var anwendungssoftwares = _context.Anwendungssoftwares.ToList();
            var softwareAbschreibungen = _context.Abschreibungen.ToList();
            _kontoManager = new KontoManager();
            var lastKontoNr = _kontoManager.GetNewDetailedKontoNr(_context, _kontoManager.KontoNrSoftware) - 1;

            foreach (var anwendungssoftware in anwendungssoftwares)
            {
                var anwendungssoftwareInAbschreibung = softwareAbschreibungen
                    .Where(c => c.Name.Equals(anwendungssoftware.Hersteller + " " + anwendungssoftware.Bezeichnung)).ToList();

                if (anwendungssoftwareInAbschreibung.Count == 0)
                {
                    lastKontoNr += 1;
                    var neueAbschreibungsAnlage = new Abschreibung()
                    {
                        Anschaffungsdatum = anwendungssoftware.Einkaufsdatum,
                        Anschaffungskosten = anwendungssoftware.Einkaufspreis,
                        KontoNr = lastKontoNr,
                        Name = anwendungssoftware.Hersteller + " " + anwendungssoftware.Bezeichnung,
                        Nutzungsdauer = nutzungsdauerSoftware
                    };
                    _context.Abschreibungen.Add(neueAbschreibungsAnlage);
                }
                else
                {
                    anwendungssoftwareInAbschreibung[0].Anschaffungsdatum = anwendungssoftware.Einkaufsdatum;
                    anwendungssoftwareInAbschreibung[0].Anschaffungskosten = anwendungssoftware.Einkaufspreis;
                    anwendungssoftwareInAbschreibung[0].Nutzungsdauer = nutzungsdauerSoftware;
                }
            }

            _context.SaveChanges();
            return RedirectToAction("IndexSoftware", "Abschreibung");
        }

        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult UebergabeUnterstuetzungssoftware()
        {
            var unterstutzungssoftwares = _context.Unterstuetzungssoftwares.ToList();
            var softwareAbschreibungen = _context.Abschreibungen.ToList();
            _kontoManager = new KontoManager();
            var lastKontoNr = _kontoManager.GetNewDetailedKontoNr(_context, _kontoManager.KontoNrSoftware) - 1;

            foreach (var unterstuetzungssoftware in unterstutzungssoftwares)
            {
                var unterstuetzungssoftwareInAbschreibung = softwareAbschreibungen
                    .Where(c => c.Name.Equals(unterstuetzungssoftware.Hersteller + " " + unterstuetzungssoftware.Bezeichnung)).ToList();

                if (unterstuetzungssoftwareInAbschreibung.Count == 0)
                {
                    lastKontoNr += 1;
                    var neueAbschreibungsAnlage = new Abschreibung()
                    {
                        Anschaffungsdatum = unterstuetzungssoftware.Einkaufsdatum,
                        Anschaffungskosten = unterstuetzungssoftware.Einkaufspreis,
                        KontoNr = lastKontoNr,
                        Name = unterstuetzungssoftware.Hersteller + " " + unterstuetzungssoftware.Bezeichnung,
                        Nutzungsdauer = nutzungsdauerSoftware
                    };
                    _context.Abschreibungen.Add(neueAbschreibungsAnlage);
                }
                else
                {
                    unterstuetzungssoftwareInAbschreibung[0].Anschaffungsdatum = unterstuetzungssoftware.Einkaufsdatum;
                    unterstuetzungssoftwareInAbschreibung[0].Anschaffungskosten = unterstuetzungssoftware.Einkaufspreis;
                    unterstuetzungssoftwareInAbschreibung[0].Nutzungsdauer = nutzungsdauerSoftware;
                }
            }

            _context.SaveChanges();
            return RedirectToAction("IndexSoftware", "Abschreibung");
        }

        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult UebergabeComputer()
        {
            var computers = _context.Computers.ToList();
            var abschreibungen = _context.Abschreibungen.ToList();
            _kontoManager = new KontoManager();
            var lastKontoNr = _kontoManager.GetNewDetailedKontoNr(_context, _kontoManager.KontoNrAusstattung) - 1;

            foreach (var computer in computers)
            {
                var computersInAbschreibung = abschreibungen
                    .Where(c => c.Name.Equals(computer.Hersteller + " " + computer.MacAdresse)).ToList();

                if (computersInAbschreibung.Count == 0)
                {
                    lastKontoNr += 1;
                    var neueAbschreibungsAnlage = new Abschreibung()
                    {
                        Anschaffungsdatum = computer.Einkaufsdatum,
                        Anschaffungskosten = computer.Einkaufspreis,
                        KontoNr = lastKontoNr,
                        Name = computer.Hersteller + " " + computer.Benutzer.Nachname + " " + computer.Benutzer.Vorname,
                        Nutzungsdauer = nutzungsdauerComputer
                    };
                    _context.Abschreibungen.Add(neueAbschreibungsAnlage);
                }
                else
                {
                    computersInAbschreibung[0].Anschaffungsdatum = computer.Einkaufsdatum;
                    computersInAbschreibung[0].Anschaffungskosten = computer.Einkaufspreis;
                    computersInAbschreibung[0].Nutzungsdauer = nutzungsdauerComputer;
                }
            }

            _context.SaveChanges();
            return RedirectToAction("IndexGeschaeftsausstattung", "Abschreibung");
        }

        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult UebergabeSonstigeAnlage()
        {
            var sonstigeAnlagen = _context.SonstigeAnlagen.Include(c=>c.Konto).ToList();
            var abschreibungen = _context.Abschreibungen.ToList();

            _kontoManager = new KontoManager();

            foreach (var sonstigeAnlage in sonstigeAnlagen)
            {

                var sonstigeAnlagenInAbschreibung = abschreibungen
                    .Where(c => c.Name.Equals(sonstigeAnlage.Bezeichnung + " " + sonstigeAnlage.Gegenstand)).ToList();

                if (sonstigeAnlagenInAbschreibung.Count == 0)
                {
                    var neueAbschreibungsAnlage = new Abschreibung()
                    {
                        Anschaffungsdatum = sonstigeAnlage.Einkaufsdatum,
                        Anschaffungskosten = sonstigeAnlage.Einkaufspreis,
                        KontoNr = _kontoManager.GetNewUnknownDetailedKontoNr(_context, sonstigeAnlage.Konto.Nummer),
                        Name = sonstigeAnlage.Bezeichnung + " " + sonstigeAnlage.Bezeichnung,
                        Nutzungsdauer = sonstigeAnlage.Nutzungsdauer
                    };
                    _context.Abschreibungen.Add(neueAbschreibungsAnlage);
                }
                {
                    sonstigeAnlagenInAbschreibung[0].Anschaffungsdatum = sonstigeAnlage.Einkaufsdatum;
                    sonstigeAnlagenInAbschreibung[0].Anschaffungskosten = sonstigeAnlage.Einkaufspreis;
                    sonstigeAnlagenInAbschreibung[0].Nutzungsdauer = sonstigeAnlage.Nutzungsdauer;
                }
            }

            _context.SaveChanges();
            return RedirectToAction("IndexGeschaeftsausstattung", "Abschreibung");
        }

    }
}