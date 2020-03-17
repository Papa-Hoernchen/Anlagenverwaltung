using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anlagenverwaltung.Dto.HardwareKomponentenDto
{
    public class MonitorDto
    {
        public MonitorDto()
        {
            this.Computers = new HashSet<ComputerDto>();
        }

        public byte Id { get; set; }
        public string Hersteller { get; set; }
        public string Produktbezeichnung { get; set; }
        public float Einkaufspreis { get; set; }
        public DateTime Einkaufsdatum { get; set; }

        public string Art { get; set; }
        public float Zoll { get; set; }
        public string Pixel { get; set; }

        public virtual ICollection<ComputerDto> Computers { get; set; }
    }
}