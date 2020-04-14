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
    public class AbschreibungGesamtController : ApiController
    {
        private ApplicationDbContext _context;
        private KontoManager _kontoManager;
        private AbschreibungsManager _abschreibungsManager;

        public AbschreibungGesamtController()
        {
            _context = new ApplicationDbContext();
            _kontoManager = new KontoManager();
            _abschreibungsManager = new AbschreibungsManager();
        }

        //GET /api/AbschreibungGesamt
        [Authorize(Roles = RoleNames.Admin)]
        public IHttpActionResult GetAnteilAOAbschreibung(string year = "")
        {
            year = year == "" ? DateTime.Now.Year.ToString() : year;

            var abschreibungGesamtInQuery =
                _context.Abschreibungen.Where(c => c.Id > 0);


            var abschreibungGesamtDtos = abschreibungGesamtInQuery
                .ToList()
                .Select(Mapper.Map<Abschreibung, AbschreibungDto>).ToList().ToList();

            var beginnBuchwert = Convert.ToDateTime("01/01/" + year);
            var endBuchwert = Convert.ToDateTime("31/12/" + year);

            for (var i = 0; i < abschreibungGesamtDtos.Count(); i++)
            {
                var nutzungsdauer = abschreibungGesamtDtos[i].Nutzungsdauer;
                var anschaffungsdatum = abschreibungGesamtDtos[i].Anschaffungsdatum;
                var anschaffungskosten = abschreibungGesamtDtos[i].Anschaffungskosten;


                abschreibungGesamtDtos[i].AfaProzent = (float)_abschreibungsManager.BerechneAfaProzent(nutzungsdauer);

                abschreibungGesamtDtos[i].BuchwertBegin = (float)_abschreibungsManager.BerechneBuchwert(anschaffungsdatum, beginnBuchwert, nutzungsdauer,
                    anschaffungskosten);

                abschreibungGesamtDtos[i].Abschreibungssatz =
                    (float)_abschreibungsManager.BerechneAbschreibungssatzJahr(anschaffungskosten, nutzungsdauer);

                abschreibungGesamtDtos[i].BuchwertEnde = (float)_abschreibungsManager.BerechneBuchwert(anschaffungsdatum, endBuchwert,
                    nutzungsdauer, anschaffungskosten);
            }

            return Ok(abschreibungGesamtDtos);
        }
    }
}
