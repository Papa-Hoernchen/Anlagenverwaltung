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
            Mapper.CreateMap<Arbeitsspeicher, ArbeitsspeicherDto>();
            Mapper.CreateMap<Computer, ComputerDto>();
            Mapper.CreateMap<Festplatte, FestplatteDto>();
            Mapper.CreateMap<Maus, MausDto>();
            Mapper.CreateMap<Monitor, MonitorDto>();
            Mapper.CreateMap<Prozessor, ProzessorDto>();
            Mapper.CreateMap<Tastatur, TastaturDto>();

            Mapper.CreateMap<ComputerDto, Computer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<FestplatteDto, Festplatte>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MonitorDto, Monitor>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
        
    }
}