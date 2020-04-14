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
    public class ArbeitsspeicherController : ApiController
    {
        private ApplicationDbContext _context;

        public ArbeitsspeicherController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/arbeitsspeicher
        public IHttpActionResult GetArbeitsspeicher()
        {
            var arbeitsspeicherQuery = _context.Arbeitsspeichers.Where(a=> a.Id > 0);

            var arbeitsspeicherDtos = arbeitsspeicherQuery
                .ToList()
                .Select(Mapper.Map<Arbeitsspeicher, ArbeitsspeicherDto>);

            return Ok(arbeitsspeicherDtos);
        }

        //DELETE /api/arbeitsspeicher/1
        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        [HttpDelete]
        public void DeleteArbeitsspeicher(int id)
        {
            var arbeitsspeicherInDb = _context.Arbeitsspeichers.SingleOrDefault(a => a.Id == id);

            if (arbeitsspeicherInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Arbeitsspeichers.Remove(arbeitsspeicherInDb);
            _context.SaveChanges();
        }
    }
}
