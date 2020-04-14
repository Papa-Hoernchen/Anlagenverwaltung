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
    public class AbschreibungAusstattungController : ApiController
    {
        private ApplicationDbContext _context;
        private KontoManager _kontoManager;
        private AbschreibungsManager _abschreibungsManager;

        public AbschreibungAusstattungController()
        {
            _context = new ApplicationDbContext();
            _kontoManager = new KontoManager();
            _abschreibungsManager = new AbschreibungsManager();
        }

        //GET /api/AbschreibungAusstattung
        [Authorize(Roles = RoleNames.Admin)]
        public IHttpActionResult GetAusstattungAbschreibung(string year = "")
        {
            year = year == "" ? DateTime.Now.Year.ToString() : year;

            var abschreibungAusstattungInQuery =
                _context.Abschreibungen.Where(c => c.KontoNr.ToString().Substring(0, 3).Contains(_kontoManager.KontoNrAusstattung.ToString()));


            var abschreibungAusstattungDtos = abschreibungAusstattungInQuery
                .ToList()
                .Select(Mapper.Map<Abschreibung, AbschreibungDto>).ToList();

            var beginnBuchwert = Convert.ToDateTime("01/01/" + year);
            var endBuchwert = Convert.ToDateTime("31/12/" + year);

            for (var i = 0; i < abschreibungAusstattungDtos.Count(); i++)
            {
                var nutzungsdauer = abschreibungAusstattungDtos[i].Nutzungsdauer;
                var anschaffungsdatum = abschreibungAusstattungDtos[i].Anschaffungsdatum;
                var anschaffungskosten = abschreibungAusstattungDtos[i].Anschaffungskosten;


                abschreibungAusstattungDtos[i].AfaProzent = (float)_abschreibungsManager.BerechneAfaProzent(nutzungsdauer);

                abschreibungAusstattungDtos[i].BuchwertBegin = (float)_abschreibungsManager.BerechneBuchwert(anschaffungsdatum, beginnBuchwert, nutzungsdauer,
                    anschaffungskosten);

                abschreibungAusstattungDtos[i].Abschreibungssatz =
                    (float)_abschreibungsManager.BerechneAbschreibungssatzJahr(anschaffungskosten, nutzungsdauer);

                abschreibungAusstattungDtos[i].BuchwertEnde = (float)_abschreibungsManager.BerechneBuchwert(anschaffungsdatum, endBuchwert,
                    nutzungsdauer, anschaffungskosten);
            }

            return Ok(abschreibungAusstattungDtos);
        }
    }
}
