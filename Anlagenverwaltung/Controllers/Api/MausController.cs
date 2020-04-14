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
    public class MausController : ApiController
    {
        private ApplicationDbContext _context;

        public MausController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/maus
        public IHttpActionResult GetMaus()
        {
            var mausInQuery = _context.Maeuse.Where(a => a.Id > 0);

            var maeuseDtos = mausInQuery
                .ToList()
                .Select(Mapper.Map<Maus, MausDto>);

            return Ok(maeuseDtos);
        }

        //DELETE /api/maus/1
        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        [HttpDelete]
        public void DeleteMaus(int id)
        {
            var mausInDb = _context.Maeuse.SingleOrDefault(a => a.Id == id);

            if (mausInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Maeuse.Remove(mausInDb);
            _context.SaveChanges();
        }
    }
}
