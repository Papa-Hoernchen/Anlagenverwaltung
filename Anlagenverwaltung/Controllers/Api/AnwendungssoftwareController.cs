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
    public class AnwendungssoftwareController : ApiController
    {
        private ApplicationDbContext _context;

        public AnwendungssoftwareController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/anwendungssoftware
        public IHttpActionResult GetAnwendungssoftware()
        {
            var anwendungssoftwareInQuery = _context.Anwendungssoftwares.Where(c=>c.Id > 0);

            var anwendungssoftwareDtos = anwendungssoftwareInQuery
                .ToList()
                .Select(Mapper.Map<Anwendungssoftware, AnwendungssoftwareDto>);

            return Ok(anwendungssoftwareDtos);
        }

        //DELETE /api/anwendungssoftware/1
        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        [HttpDelete]
        public void DeleteAnwendungssoftware(int id)
        {
            var anwendungssoftwareInDb = _context.Anwendungssoftwares.SingleOrDefault(a => a.Id == id);

            if (anwendungssoftwareInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Anwendungssoftwares.Remove(anwendungssoftwareInDb);
            _context.SaveChanges();
        }
    }
}
