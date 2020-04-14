using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Anlagenverwaltung.Models;
using Anlagenverwaltung.ViewModels;
using Anlagenverwaltung.Controllers;
using Microsoft.AspNet.Identity;

namespace Anlagenverwaltung.Controllers
{
    public class ChangeRoleController : Controller
    {
        private ApplicationDbContext _context;

        public ChangeRoleController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: ChangeRole
        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult Index()
        {
            //var roles = _context.Users.ToList();
            //var role = roles[0].
            var viewModel = new ChangeRoleViewModel()
            {
                ApplicationUsers = _context.Users.ToList(),
                IdentityRoles = _context.Roles.ToList(),
                RoleName = "",
                UserId = ""
            };
            return View(viewModel);
        }


    }
}