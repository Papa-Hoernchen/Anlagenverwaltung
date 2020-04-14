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
    public class FestplatteController : ApiController
    {
        private ApplicationDbContext _context;

        public FestplatteController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/festplatte
        public IHttpActionResult GetFestplatte()
        {
            var festplattenQuery = _context.Festplatten.Where(f => f.Id > 0);

            var festplatteInDtos = festplattenQuery
                .ToList()
                .Select(Mapper.Map<Festplatte, FestplatteDto>);

            return Ok(festplatteInDtos);
        }

        //DELETE /api/festplatte/1
        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        [HttpDelete]
        public void DeleteFestplatte(int id)
        {
            var festplatteInDb = _context.Festplatten.SingleOrDefault(f => f.Id == id);

            if (festplatteInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Festplatten.Remove(festplatteInDb);
            _context.SaveChanges();
        }
    }
}
