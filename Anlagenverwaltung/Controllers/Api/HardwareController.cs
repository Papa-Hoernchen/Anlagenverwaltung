using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
        public IHttpActionResult GetHardware(string query = null)
        {

            return Ok();
        }
    }
}
