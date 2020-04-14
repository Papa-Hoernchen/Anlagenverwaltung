using Anlagenverwaltung.Dto;
using Anlagenverwaltung.Dto.HardwareKomponentenDto;
using Anlagenverwaltung.Dto.SoftwareKomponentenDto;
using Anlagenverwaltung.Models;
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
            Mapper.CreateMap<Betriebssystem, BetriebssystemDto>();
            Mapper.CreateMap<Anwendungssoftware, AnwendungssoftwareDto>();
            Mapper.CreateMap<Unterstuetzungssoftware, UnterstuetzungssoftwareDto>();
            Mapper.CreateMap<SonstigeAnlage, SonstigeAnlageDto>();
            Mapper.CreateMap<Abschreibung, AbschreibungDto>();
            Mapper.CreateMap<Benutzer, BenutzerDto>();

            Mapper.CreateMap<ComputerDto, Computer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<FestplatteDto, Festplatte>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MonitorDto, Monitor>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<AnwendungssoftwareDto, Anwendungssoftware>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<UnterstuetzungssoftwareDto, Unterstuetzungssoftware>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
        
    }
}