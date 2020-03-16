using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anlagenverwaltung.Models.HardwareKomponenten
{

    public class Monitor : Hardware
    {
        public Monitor()
        {
            this.Computers = new HashSet<Computer>();
        }

        public string Art { get; set; }
        public float Zoll { get; set; }
        public string Pixel { get; set; }

        public virtual ICollection<Computer> Computers { get; set; }
    }
}