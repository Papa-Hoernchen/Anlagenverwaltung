using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Anlagenverwaltung.Dto.HardwareKomponentenDto;
using Anlagenverwaltung.Dto.SoftwareKomponentenDto;
using Anlagenverwaltung.Models.HardwareKomponenten;
using Anlagenverwaltung.Models.SoftwareKomponenten;
using AutoMapper;

namespace Anlagenverwaltung.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Hardware, HardwareDto>()
                .Include<Arbeitsspeicher, ArbeitsspeicherDto>()
                .Include<Computer, ComputerDto>()
                .Include<Festplatte, FestplatteDto>()
                .Include<Maus, MausDto>()
                .Include<Monitor, MonitorDto>()
                .Include<Prozessor, ProzessorDto>()
                .Include<Tastatur, TastaturDto>();

            Mapper.CreateMap<Software, SoftwareDto>()
                .Include<Anwendungssoftware, AnwendungssoftwareDto>()
                .Include<Systemsoftware, SystemsoftwareDto>()
                .Include<Unterstuetzungssoftware, UnterstuetzungssoftwareDto>();

            Mapper.CreateMap<HardwareDto, Hardware>()
                .ForMember(c => c.Id, opt => opt.Ignore()) //Achtung
                .Include<ArbeitsspeicherDto, Arbeitsspeicher>()
                .Include<ComputerDto, Computer>()
                .Include<FestplatteDto, Festplatte>()
                .Include<MausDto, Maus>()
                .Include<MonitorDto, Monitor>()
                .Include<ProzessorDto, Prozessor>()
                .Include<TastaturDto, Tastatur>();

            Mapper.CreateMap<SoftwareDto, Software>()
                .ForMember(c => c.Id, opt => opt.Ignore()) //Achtung
                .Include<AnwendungssoftwareDto, Anwendungssoftware>()
                .Include<SystemsoftwareDto, Systemsoftware>()
                .Include<UnterstuetzungssoftwareDto, Unterstuetzungssoftware>();
        }
        
    }
}