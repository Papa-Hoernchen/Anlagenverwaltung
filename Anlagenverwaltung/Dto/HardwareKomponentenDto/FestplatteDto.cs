using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anlagenverwaltung.Dto.HardwareKomponentenDto
{
    public class FestplatteDto : HardwareDto
    {
        public FestplatteDto()
        {
            this.Computers = new HashSet<ComputerDto>();
        }
        public string Art { get; set; }
        public int Speicherkapazitaet { get; set; }
        public string Schnittstelle { get; set; }

        public virtual ICollection<ComputerDto> Computers { get; set; }
    }
}