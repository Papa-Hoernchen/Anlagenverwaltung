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
    public class MonitorController : ApiController
    {
        private ApplicationDbContext _context;

        public MonitorController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/monitor
        public IHttpActionResult GetMonitor()
        {
            var monitorQuery = _context.Monitore.Where(a => a.Id > 0);

            var monitorDtos = monitorQuery
                .ToList()
                .Select(Mapper.Map<Monitor, MonitorDto>);

            return Ok(monitorDtos);
        }

        //DELETE /api/monitor/1
        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        [HttpDelete]
        public void DeleteMonitor(int id)
        {
            var monitorInDb = _context.Monitore.SingleOrDefault(a => a.Id == id);

            if (monitorInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Monitore.Remove(monitorInDb);
            _context.SaveChanges();
        }
    }
}
