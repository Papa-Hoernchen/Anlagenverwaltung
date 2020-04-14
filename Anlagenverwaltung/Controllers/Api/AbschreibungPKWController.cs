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
    public class AbschreibungPKWController : ApiController
    {
        private ApplicationDbContext _context;
        private KontoManager _kontoManager;
        private AbschreibungsManager _abschreibungsManager;

        public AbschreibungPKWController()
        {
            _context = new ApplicationDbContext();
            _kontoManager = new KontoManager();
            _abschreibungsManager = new AbschreibungsManager();
        }

        //GET /api/AbschreibungPkw
        [Authorize(Roles = RoleNames.Admin)]
        public IHttpActionResult GetPkwAbschreibung(string year = "")
        {
            year = year == "" ? DateTime.Now.Year.ToString() : year;

            var abschreibungPkwInQuery =
                _context.Abschreibungen.Where(c => c.KontoNr.ToString().Substring(0, 3).Contains(_kontoManager.KontoNrPkw.ToString()));


            var abschreibungPkwDtos = abschreibungPkwInQuery
                .ToList()
                .Select(Mapper.Map<Abschreibung, AbschreibungDto>).ToList();

            var beginnBuchwert = Convert.ToDateTime("01/01/" + year);
            var endBuchwert = Convert.ToDateTime("31/12/" + year);

            for (var i = 0; i < abschreibungPkwDtos.Count(); i++)
            {
                var nutzungsdauer = abschreibungPkwDtos[i].Nutzungsdauer;
                var anschaffungsdatum = abschreibungPkwDtos[i].Anschaffungsdatum;
                var anschaffungskosten = abschreibungPkwDtos[i].Anschaffungskosten;


                abschreibungPkwDtos[i].AfaProzent = (float)_abschreibungsManager.BerechneAfaProzent(nutzungsdauer);

                abschreibungPkwDtos[i].BuchwertBegin = (float)_abschreibungsManager.BerechneBuchwert(anschaffungsdatum, beginnBuchwert, nutzungsdauer,
                    anschaffungskosten);

                abschreibungPkwDtos[i].Abschreibungssatz =
                    (float)_abschreibungsManager.BerechneAbschreibungssatzJahr(anschaffungskosten, nutzungsdauer);

                abschreibungPkwDtos[i].BuchwertEnde = (float)_abschreibungsManager.BerechneBuchwert(anschaffungsdatum, endBuchwert,
                    nutzungsdauer, anschaffungskosten);
            }

            return Ok(abschreibungPkwDtos);
        }
    }
}
