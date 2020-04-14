using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Anlagenverwaltung.Dto;
using Anlagenverwaltung.Models;
using AutoMapper;

namespace Anlagenverwaltung.Controllers.Api
{
    /// <summary>
    /// API Controller, der die REST Kommunikation zwiscchen Client und Software verwaltet
    /// </summary>
    public class AbschreibungSoftwareController : ApiController
    {
        /// <summary>
        /// Gateway zur Datenbank
        /// </summary>
        private ApplicationDbContext _context;
        /// <summary>
        /// Verwaltet die Kontonummernvergabe
        /// </summary>
        private KontoManager _kontoManager;
        /// <summary>
        /// Führt die eigentliche Abschreibungsberechnung durch
        /// </summary>
        private AbschreibungsManager _abschreibungsManager;

        /// <summary>
        /// Konstruktor, der die Attribute _context, _kontoManager und _abschreibungsManager neu initialisiert
        /// </summary>
        public AbschreibungSoftwareController()
        {
            _context = new ApplicationDbContext();
            _kontoManager = new KontoManager();
            _abschreibungsManager = new AbschreibungsManager();
        }

        /// <summary>
        /// Liefert die berechneten Abschreibungsdaten
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        //GET /api/AbschreibungSoftware
        [Authorize(Roles = RoleNames.Admin)]
        public IHttpActionResult GetSoftwareAbschreibung(string year = "")
        {
            year = year == "" ? DateTime.Now.Year.ToString() : year;

            var abschreibungSoftwareInQuery =
                _context.Abschreibungen.Where(c => c.KontoNr.ToString().Substring(0, 2).Contains(_kontoManager.KontoNrSoftware.ToString()));


            var abschreibungSoftwareDtos = abschreibungSoftwareInQuery
                .ToList()
                .Select(Mapper.Map<Abschreibung, AbschreibungDto>).ToList();

            var beginnBuchwert = Convert.ToDateTime("01/01/" + year);
            var endBuchwert = Convert.ToDateTime("31/12/" + year);

            for (var i = 0; i < abschreibungSoftwareDtos.Count(); i++)
            {
                var nutzungsdauer = abschreibungSoftwareDtos[i].Nutzungsdauer;
                var anschaffungsdatum = abschreibungSoftwareDtos[i].Anschaffungsdatum;
                var anschaffungskosten = abschreibungSoftwareDtos[i].Anschaffungskosten;


                abschreibungSoftwareDtos[i].AfaProzent = (float) _abschreibungsManager.BerechneAfaProzent(nutzungsdauer);

                abschreibungSoftwareDtos[i].BuchwertBegin = (float) _abschreibungsManager.BerechneBuchwert(anschaffungsdatum, beginnBuchwert, nutzungsdauer,
                    anschaffungskosten);

                abschreibungSoftwareDtos[i].Abschreibungssatz =
                    (float) _abschreibungsManager.BerechneAbschreibungssatzJahr(anschaffungskosten, nutzungsdauer);

                abschreibungSoftwareDtos[i].BuchwertEnde = (float) _abschreibungsManager.BerechneBuchwert(anschaffungsdatum, endBuchwert,
                    nutzungsdauer, anschaffungskosten);
            }

            return Ok(abschreibungSoftwareDtos);
        }
    }
}
