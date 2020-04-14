using Anlagenverwaltung.Dto.HardwareKomponentenDto;
using Anlagenverwaltung.Models;
using Anlagenverwaltung.Models.HardwareKomponenten;
using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Anlagenverwaltung.Controllers.Api
{
    public class ComputerController : ApiController
    {
        private ApplicationDbContext _context;

        public ComputerController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/computer
        public IHttpActionResult GetComputers()
        {
            var computersQuery = _context.Computers
                .Include(c => c.Arbeitsspeicher)
                .Include(c => c.Maus)
                .Include(c => c.Prozessor)
                .Include(c => c.Tastatur)
                .Include(c => c.Festplatten)
                .Include(c => c.Monitore)
                .Include(c => c.Anwendungssoftware)
                .Include(c => c.Betriebssystem)
                .Include(c => c.Unterstuetzungssoftware)
                .Include(c => c.Benutzer);

            var computerDtos = computersQuery
                .ToList()
                .Select(Mapper.Map<Computer, ComputerDto>);

            return Ok(computerDtos);
        }

        // GET /api/computer/1
        public IHttpActionResult GetComputer(int id)
        {
            var computer = _context.Computers
                .Include(c => c.Arbeitsspeicher)
                .Include(c => c.Maus)
                .Include(c => c.Prozessor)
                .Include(c => c.Tastatur)
                .Include(c => c.Festplatten)
                .Include(c => c.Monitore)
                .Include(c=> c.Betriebssystem)
                .Include(c => c.Anwendungssoftware)
                .Include(c => c.Unterstuetzungssoftware)
                .Include(c=> c.Konto)
                .First(c => c.Id == id);

            if (computer == null)
                return NotFound();

            return Ok(Mapper.Map<Computer, ComputerDto>(computer));
        }

        //DELETE /api/computer/1
        [Authorize(Roles = RoleNames.Admin + "," + RoleNames.CanUseVerwaltung)]
        [HttpDelete]
        public void DeleteComputer(int id)
        {
            var computerInDb = _context.Computers.SingleOrDefault(c => c.Id == id);

            if (computerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Computers.Remove(computerInDb);
            _context.SaveChanges();
        }
    }
}
