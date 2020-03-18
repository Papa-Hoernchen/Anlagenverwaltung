using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Anlagenverwaltung.Models;
using Anlagenverwaltung.Models.HardwareKomponenten;
using Anlagenverwaltung.ViewModels;

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

        //public ActionResult Edit(int id)
        //{
        //    var computer = _context.Computers.SingleOrDefault(c => c.Id == id);

        //    if (computer == null)
        //        return HttpNotFound();


        //    var viewModel = new ComputerFormViewModel()
        //    {
        //        Computer = computer,
        //    //    Arbeitsspeichers = _context.

        //    };

        //  //  return View("CustomerForm", viewModel);

     //   }
    }
}