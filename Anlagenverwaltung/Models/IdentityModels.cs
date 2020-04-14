using Anlagenverwaltung.Models.HardwareKomponenten;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Anlagenverwaltung.Models.SoftwareKomponenten;

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
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Festplatte> Festplatten { get; set; }
        public DbSet<Monitor> Monitore { get; set; }
        public DbSet<Arbeitsspeicher> Arbeitsspeichers { get; set; }
        public DbSet<Maus> Maeuse { get; set; }
        public DbSet<Prozessor> Prozessoren { get; set; }
        public DbSet<Tastatur> Tastaturen { get; set; }

        public DbSet<Betriebssystem> Betriebssysteme { get; set; }
        public DbSet<Anwendungssoftware> Anwendungssoftwares { get; set; }
        public DbSet<Unterstuetzungssoftware> Unterstuetzungssoftwares { get; set; }

        public DbSet<SonstigeAnlage> SonstigeAnlagen { get; set; }

        public DbSet<Konto> Konten { get; set; }
        public DbSet<Abschreibung> Abschreibungen { get; set; }

        public DbSet<Benutzer> Benutzers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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