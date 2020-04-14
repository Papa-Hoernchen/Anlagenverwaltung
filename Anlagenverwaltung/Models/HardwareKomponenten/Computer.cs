using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Anlagenverwaltung.Models.SoftwareKomponenten;

namespace Anlagenverwaltung.Models.HardwareKomponenten
{
    public class Computer
    {
        private List<int> _festplattenIds;
        private List<int> _monitorenIds;

        public Computer()
        {
            this.Festplatten = new HashSet<Festplatte>();
            this.Monitore = new HashSet<Monitor>();
            this.Anwendungssoftware = new HashSet<Anwendungssoftware>();
            this.Unterstuetzungssoftware = new HashSet<Unterstuetzungssoftware>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Hersteller { get; set; }
        [Display(Name = "Mac-Adresse")]
        public string MacAdresse { get; set; }
        public float Einkaufspreis { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
                "{0:dd-MM-yyyy}",
            ApplyFormatInEditMode = true)]
        public DateTime Einkaufsdatum { get; set; }

        public Arbeitsspeicher Arbeitsspeicher { get; set; }
        [Display(Name = "Arbeitsspeicher")]
        public byte ArbeitsspeicherId { get; set; }

        public Prozessor Prozessor { get; set; }
        [Display(Name = "Prozessor")]
        public byte ProzessorId { get; set; }

        public Maus Maus { get; set; }
        [Display(Name = "Maus")]
        public byte MausId { get; set; }

        public Tastatur Tastatur { get; set; }
        [Display(Name = "Tastatur")]
        public byte TastaturId { get; set; }

        public virtual ICollection<Festplatte> Festplatten { get; set; }
        [NotMapped]
        public List<int> FestplattenIds {
            get
            {
                if (_festplattenIds == null)
                {
                    _festplattenIds = new List<int>();
                    foreach (var festplatte in Festplatten)
                        _festplattenIds.Add(festplatte.Id);
                }
                return _festplattenIds;
            }
            set { _festplattenIds = value; }
        }

        public virtual ICollection<Monitor> Monitore { get; set; }
        [NotMapped]
        public List<int> MonitorenIds
        {
            get
            {
                if (_monitorenIds == null)
                {
                    _monitorenIds = new List<int>();
                    foreach (var monitor in Monitore)
                        _monitorenIds.Add(monitor.Id);
                }
                return _monitorenIds;
            }
            set { _monitorenIds = value; }
        }

        public Betriebssystem Betriebssystem { get; set; }
        [Display(Name = "Betriebssystem")]
        public int BetriebssystemId { get; set; }

        public virtual ICollection<Anwendungssoftware> Anwendungssoftware { get; set; }
        public virtual ICollection<Unterstuetzungssoftware> Unterstuetzungssoftware { get; set; }

        public Konto Konto { get; set; }
        public int? KontoId { get; set; }

        public Benutzer Benutzer { get; set; }
        public int? BenutzerId { get; set; }

    }
}