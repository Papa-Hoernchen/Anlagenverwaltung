using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Anlagenverwaltung.Models.HardwareKomponenten;
using Anlagenverwaltung.Models.SoftwareKomponenten;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Anlagenverwaltung.Models
{
    // Sie können Profildaten für den Benutzer hinzufügen, indem Sie der ApplicationUser-Klasse weitere Eigenschaften hinzufügen. Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Beachten Sie, dass der "authenticationType" mit dem in "CookieAuthenticationOptions.AuthenticationType" definierten Typ übereinstimmen muss.
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Benutzerdefinierte Benutzeransprüche hier hinzufügen
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Hardware> Hardwares { get; set; }
        public DbSet<Software> Softwares { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Konkrete Typen von Hardware
            modelBuilder.Entity<Arbeitsspeicher>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Arbeitsspeicher");
            });
            modelBuilder.Entity<Computer>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Computer");
            });
            modelBuilder.Entity<Festplatte>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Festplatte");
            });
            modelBuilder.Entity<Maus>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Maus");
            });
            modelBuilder.Entity<Monitor>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Monitor");
            });
            modelBuilder.Entity<Prozessor>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Prozessor");
            });
            modelBuilder.Entity<Tastatur>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Tastatur");
            });

            //Konkrete Typen von Software
            modelBuilder.Entity<Anwendungssoftware>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Anwendungssoftware");
            });
            modelBuilder.Entity<Systemsoftware>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Systemsoftware");
            });
            modelBuilder.Entity<Unterstuetzungssoftware>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Unterstuetzungssoftware");
            });

        }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}