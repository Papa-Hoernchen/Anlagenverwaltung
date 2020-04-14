using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Anlagenverwaltung.Dto.SoftwareKomponentenDto;
using Anlagenverwaltung.Models;
using Anlagenverwaltung.Models.SoftwareKomponenten;
using AutoMapper;

namespace Anlagenverwaltung.Controllers.Api
{
    public class BetriebssystemController : ApiController
    {
        private ApplicationDbContext _context;

        public BetriebssystemController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/betriebssystem
        public IHttpActionResult GetBetriebssysteme()
        {
            var betriebssystemInQuery = _context.Betriebssysteme.Where(c => c.Id > 0);

            var betriebssystemDtos = betriebssystemInQuery
                .ToList()
                .Select(Mapper.Map<Betriebssystem, BetriebssystemDto>);

            return Ok(betriebssystemDtos);
        }

        //DELETE /api/betriebssystem/1
        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        [HttpDelete]
        public void DeleteBetriebssystem(int id)
        {
            var betriebssystemInDb = _context.Betriebssysteme.SingleOrDefault(a => a.Id == id);

            if (betriebssystemInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Betriebssysteme.Remove(betriebssystemInDb);
            _context.SaveChanges();
        }
    }
}
