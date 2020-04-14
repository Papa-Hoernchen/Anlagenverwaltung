using System;
using System.Collections.Generic;
using Anlagenverwaltung.Dto.SoftwareKomponentenDto;

namespace Anlagenverwaltung.Dto.HardwareKomponentenDto
{
    public class ComputerDto
    {
        public ComputerDto()
        {
            this.Festplatten = new HashSet<FestplatteDto>();
            this.Monitore = new HashSet<MonitorDto>();
            this.Anwendungssoftware = new HashSet<AnwendungssoftwareDto>();
            this.Unterstuetzungssoftware = new HashSet<UnterstuetzungssoftwareDto>();
        }

        public int Id { get; set; }

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

        public BetriebssystemDto Betriebssystem { get; set; }
        public int BetriebssystemId { get; set; }

        public virtual ICollection<FestplatteDto> Festplatten { get; set; }
        public virtual ICollection<MonitorDto> Monitore { get; set; }

        public virtual ICollection<AnwendungssoftwareDto> Anwendungssoftware { get; set; }
        public virtual ICollection<UnterstuetzungssoftwareDto> Unterstuetzungssoftware { get; set; }

        public KontoDto Konto { get; set; }
        public int? KontoId { get; set; }

        public BenutzerDto Benutzer { get; set; }
        public int? BenutzerId { get; set; }
    }
}