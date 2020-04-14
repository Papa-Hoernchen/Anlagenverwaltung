using Anlagenverwaltung.Dto.HardwareKomponentenDto;
using Anlagenverwaltung.Models;
using Anlagenverwaltung.Models.HardwareKomponenten;
using AutoMapper;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Anlagenverwaltung.Controllers.Api
{
    public class TastaturController : ApiController
    {
        private ApplicationDbContext _context;

        public TastaturController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/tastatur
        public IHttpActionResult GetTastatur()
        {
            var tastaturQuery = _context.Tastaturen.Where(a => a.Id > 0);

            var tastaturDtos = tastaturQuery
                .ToList()
                .Select(Mapper.Map<Tastatur, TastaturDto>);

            return Ok(tastaturDtos);
        }

        //DELETE /api/tastatur/1
        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        [HttpDelete]
        public void DeleteTastatur(int id)
        {
            var tastaturInDb = _context.Tastaturen.SingleOrDefault(a => a.Id == id);

            if (tastaturInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Tastaturen.Remove(tastaturInDb);
            _context.SaveChanges();
        }
    }
}
