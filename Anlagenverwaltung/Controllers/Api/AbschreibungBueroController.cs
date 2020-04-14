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
    public class AbschreibungBueroController : ApiController
    {
        private ApplicationDbContext _context;
        private KontoManager _kontoManager;
        private AbschreibungsManager _abschreibungsManager;

        public AbschreibungBueroController()
        {
            _context = new ApplicationDbContext();
            _kontoManager = new KontoManager();
            _abschreibungsManager = new AbschreibungsManager();
        }

        //GET /api/AbschreibungBuero
        [Authorize(Roles = RoleNames.Admin)]
        public IHttpActionResult GetBueroAbschreibung(string year = "")
        {
            year = year == "" ? DateTime.Now.Year.ToString() : year;

            var abschreibungBueroInQuery =
                _context.Abschreibungen.Where(c => c.KontoNr.ToString().Substring(0, 3).Contains(_kontoManager.KontoNrBueroeinrichtung.ToString()));


            var abschreibungBueroDtos = abschreibungBueroInQuery
                .ToList()
                .Select(Mapper.Map<Abschreibung, AbschreibungDto>).ToList();

            var beginnBuchwert = Convert.ToDateTime("01/01/" + year);
            var endBuchwert = Convert.ToDateTime("31/12/" + year);

            for (var i = 0; i < abschreibungBueroDtos.Count(); i++)
            {
                var nutzungsdauer = abschreibungBueroDtos[i].Nutzungsdauer;
                var anschaffungsdatum = abschreibungBueroDtos[i].Anschaffungsdatum;
                var anschaffungskosten = abschreibungBueroDtos[i].Anschaffungskosten;


                abschreibungBueroDtos[i].AfaProzent = (float)_abschreibungsManager.BerechneAfaProzent(nutzungsdauer);

                abschreibungBueroDtos[i].BuchwertBegin = (float)_abschreibungsManager.BerechneBuchwert(anschaffungsdatum, beginnBuchwert, nutzungsdauer,
                    anschaffungskosten);

                abschreibungBueroDtos[i].Abschreibungssatz =
                    (float)_abschreibungsManager.BerechneAbschreibungssatzJahr(anschaffungskosten, nutzungsdauer);

                abschreibungBueroDtos[i].BuchwertEnde = (float)_abschreibungsManager.BerechneBuchwert(anschaffungsdatum, endBuchwert,
                    nutzungsdauer, anschaffungskosten);
            }

            return Ok(abschreibungBueroDtos);
        }
    }
}
