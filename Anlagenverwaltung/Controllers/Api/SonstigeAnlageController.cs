using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Anlagenverwaltung.Dto;
using Anlagenverwaltung.Dto.SoftwareKomponentenDto;
using Anlagenverwaltung.Models;
using Anlagenverwaltung.Models.SoftwareKomponenten;
using AutoMapper;

namespace Anlagenverwaltung.Controllers.Api
{
    public class SonstigeAnlageController : ApiController
    {
        private ApplicationDbContext _context;

        public SonstigeAnlageController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/sonstigeAnlage
        public IHttpActionResult GetSonstigeAnlage()
        {
            var sonstigeAnlageInQuery = _context.SonstigeAnlagen.Where(c => c.Id > 0);

            var sonstigeAnlageDtos = sonstigeAnlageInQuery
                .ToList()
                .Select(Mapper.Map<SonstigeAnlage, SonstigeAnlageDto>);

            return Ok(sonstigeAnlageDtos);
        }

        //DELETE /api/sonstigeAnlage/1
        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        [HttpDelete]
        public void DeleteSonstigeAnlage(int id)
        {
            var sonstigeAnlageInDb = _context.SonstigeAnlagen.SingleOrDefault(a => a.Id == id);

            if (sonstigeAnlageInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.SonstigeAnlagen.Remove(sonstigeAnlageInDb);
            _context.SaveChanges();
        }
    }
}
