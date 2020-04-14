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
    public class AbschreibungAnteilAOController : ApiController
    {
        private ApplicationDbContext _context;
        private KontoManager _kontoManager;
        private AbschreibungsManager _abschreibungsManager;

        public AbschreibungAnteilAOController()
        {
            _context = new ApplicationDbContext();
            _kontoManager = new KontoManager();
            _abschreibungsManager = new AbschreibungsManager();
        }

        //GET /api/AbschreibungAnteilAO
        [Authorize(Roles = RoleNames.Admin)]
        public IHttpActionResult GetAnteilAOAbschreibung(string year = "")
        {
            year = year == "" ? DateTime.Now.Year.ToString() : year;

            var abschreibungAnteilAOInQuery =
                _context.Abschreibungen.Where(c => c.KontoNr.ToString().Substring(0, 3).Contains(_kontoManager.KontoNrAnteilAO.ToString()));


            var abschreibungAnteilAODtos = abschreibungAnteilAOInQuery
                .ToList()
                .Select(Mapper.Map<Abschreibung, AbschreibungDto>).ToList();

            var beginnBuchwert = Convert.ToDateTime("01/01/" + year);
            var endBuchwert = Convert.ToDateTime("31/12/" + year);

            for (var i = 0; i < abschreibungAnteilAODtos.Count(); i++)
            {
                var nutzungsdauer = abschreibungAnteilAODtos[i].Nutzungsdauer;
                var anschaffungsdatum = abschreibungAnteilAODtos[i].Anschaffungsdatum;
                var anschaffungskosten = abschreibungAnteilAODtos[i].Anschaffungskosten;


                abschreibungAnteilAODtos[i].AfaProzent = (float)_abschreibungsManager.BerechneAfaProzent(nutzungsdauer);

                abschreibungAnteilAODtos[i].BuchwertBegin = (float)_abschreibungsManager.BerechneBuchwert(anschaffungsdatum, beginnBuchwert, nutzungsdauer,
                    anschaffungskosten);

                abschreibungAnteilAODtos[i].Abschreibungssatz =
                    (float)_abschreibungsManager.BerechneAbschreibungssatzJahr(anschaffungskosten, nutzungsdauer);

                abschreibungAnteilAODtos[i].BuchwertEnde = (float)_abschreibungsManager.BerechneBuchwert(anschaffungsdatum, endBuchwert,
                    nutzungsdauer, anschaffungskosten);
            }

            return Ok(abschreibungAnteilAODtos);
        }
    }
}
