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
    public class ProzessorController : ApiController
    {
        private ApplicationDbContext _context;

        public ProzessorController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/prozessor
        public IHttpActionResult GetProzessor()
        {
            var prozessorQuery = _context.Prozessoren.Where(a => a.Id > 0);

            var prozessorDtos = prozessorQuery
                .ToList()
                .Select(Mapper.Map<Prozessor, ProzessorDto>);

            return Ok(prozessorDtos);
        }

        //DELETE /api/prozessor/1
        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        [HttpDelete]
        public void DeleteProzessor(int id)
        {
            var prozessorInDto = _context.Prozessoren.SingleOrDefault(a => a.Id == id);

            if (prozessorInDto == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Prozessoren.Remove(prozessorInDto);
            _context.SaveChanges();
        }
    }
}
