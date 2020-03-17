using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anlagenverwaltung.Dto.HardwareKomponentenDto
{
    public class ComputerDto
    {
        public ComputerDto()
        {
            this.Festplatten = new HashSet<FestplatteDto>();
            this.Monitore = new HashSet<MonitorDto>();
        }

        public byte Id { get; set; }

        public string Hersteller { get; set; }
        public string MacAdresse { get; set; }
        public float Einkaufspreis { get; set; }
        public DateTime Einkaufsdatum { get; set; }

        public ArbeitsspeicherDto Arbeitsspeicher { get; set; }
        public byte ArbeitsspeicherId { get; set; }

        public ProzessorDto Prozessor { get; set; }
        public byte ProzessorId { get; set; }

        public MausDto Maus { get; set; }
        public byte MausId { get; set; }

        public TastaturDto Tastatur { get; set; }
        public byte TastaturId { get; set; }

        public virtual ICollection<FestplatteDto> Festplatten { get; set; }
        public virtual ICollection<MonitorDto> Monitore { get; set; }
    }
}