using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Anlagenverwaltung.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Anlagenverwaltung.ViewModels
{
    public class ChangeRoleViewModel
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
        public IEnumerable<IdentityRole> IdentityRoles { get; set; }
    }
}