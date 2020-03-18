using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Anlagenverwaltung.Dto.HardwareKomponentenDto;
using Anlagenverwaltung.Models;
using Anlagenverwaltung.Models.HardwareKomponenten;
using AutoMapper;

namespace Anlagenverwaltung.Controllers.Api
{
    public class HardwareController : ApiController
    {
        private ApplicationDbContext _context;

        public HardwareController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/hardware
        public IHttpActionResult GetComputers(string query = null)
        {
            var computersQuery = _context.Computers
                .Include(c => c.Arbeitsspeicher)
                .Include(c => c.Maus)
                .Include(c => c.Prozessor)
                .Include(c => c.Tastatur);

            if (!String.IsNullOrWhiteSpace(query))
                computersQuery = computersQuery.Where(c => c.MacAdresse.Contains(query));

            var computerDtos = computersQuery
                .ToList()
                .Select(Mapper.Map<Computer, ComputerDto>);



            return Ok(computerDtos);
        }
    }
}
