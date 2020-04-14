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
    public class UnterstuetzungssoftwareController : ApiController
    {
        private ApplicationDbContext _context;

        public UnterstuetzungssoftwareController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/unterstuetzungssoftware
        public IHttpActionResult GetUnterstuetzungssoftware()
        {
            var unterstuetzungssoftwareInQuery = _context.Unterstuetzungssoftwares.Where(c => c.Id > 0);

            var unterstuetzungssoftwareDtos = unterstuetzungssoftwareInQuery
                .ToList()
                .Select(Mapper.Map<Unterstuetzungssoftware, UnterstuetzungssoftwareDto>);

            return Ok(unterstuetzungssoftwareDtos);
        }

        //DELETE /api/unterstuetzungssoftware/1
        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        [HttpDelete]
        public void DeleteUnterstuetzungssoftware(int id)
        {
            var unterstuetzungssoftwareInDb = _context.Unterstuetzungssoftwares.SingleOrDefault(a => a.Id == id);

            if (unterstuetzungssoftwareInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Unterstuetzungssoftwares.Remove(unterstuetzungssoftwareInDb);
            _context.SaveChanges();
        }
    }
}
