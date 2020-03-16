using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anlagenverwaltung.Dto.HardwareKomponentenDto
{
    public class ComputerDto : HardwareDto
    {
        public ComputerDto()
        {
            this.Festplatten = new HashSet<FestplatteDto>();
            this.Monitore = new HashSet<MonitorDto>();
        }

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