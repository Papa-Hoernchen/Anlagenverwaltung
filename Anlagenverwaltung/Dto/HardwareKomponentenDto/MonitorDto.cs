using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anlagenverwaltung.Dto.HardwareKomponentenDto
{
    public class MonitorDto : HardwareDto
    {
        public MonitorDto()
        {
            this.Computers = new HashSet<ComputerDto>();
        }

        public string Art { get; set; }
        public float Zoll { get; set; }
        public string Pixel { get; set; }

        public virtual ICollection<ComputerDto> Computers { get; set; }
    }
}