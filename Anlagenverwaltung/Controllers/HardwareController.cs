using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Anlagenverwaltung.Models;
using Anlagenverwaltung.Models.HardwareKomponenten;

namespace Anlagenverwaltung.Controllers
{
    public class HardwareController : Controller
    {
        private ApplicationDbContext _context;

        public HardwareController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        
        // GET: Hardware
        public ActionResult Index()
        {
            return View();
        }
    }
}