using System;
using Anlagenverwaltung.Models.HardwareKomponenten;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Anlagenverwaltung.Models.SoftwareKomponenten;

namespace Anlagenverwaltung.ViewModels
{
    public class ComputerFormViewModel
    {
        public IEnumerable<Arbeitsspeicher> Arbeitsspeichers { get; set; }
        public IEnumerable<Maus> Mauese { get; set; }
        public IEnumerable<Prozessor> Prozessoren { get; set; }
        public IEnumerable<Tastatur> Tastaturen { get; set; }
        public IEnumerable<Betriebssystem> Betriebssysteme { get; set; }

        public Computer Computer { get; set; }
        public IEnumerable<SelectListItem> Festplatten { get; set; }
        public IEnumerable<SelectListItem> Monitore { get; set; }
        public IEnumerable<SelectListItem> Anwendungssoftware { get; set; }
        public IEnumerable<SelectListItem> Unterstuetzungssoftware { get; set; }


        private List<int> _selectedFestplatten;

        public List<int> SelectedFestplatten
        {
            get
            {
                if (_selectedFestplatten == null && Computer != null)
                {
                    _selectedFestplatten = Computer.Festplatten.Select(m => m.Id).ToList();
                }

                return _selectedFestplatten;
            }
            set { _selectedFestplatten = value; }
        }

        private List<int> _selectedMonitore;

        public List<int> SelectedMonitore
        {
            get
            {
                if (_selectedMonitore == null && Computer != null)
                {
                    _selectedMonitore = Computer.Monitore.Select(m => m.Id).ToList();
                }

                return _selectedMonitore;
            }
            set { _selectedMonitore = value; }
        }

        private List<int> _selectedAnwendungsSoftware;

        public List<int> SelectedAnwendungsSoftware
        {
            get
            {
                if (_selectedAnwendungsSoftware == null && Computer != null)
                {
                    _selectedAnwendungsSoftware = Computer.Anwendungssoftware.Select(m => m.Id).ToList();
                }

                return _selectedAnwendungsSoftware;
            }
            set { _selectedAnwendungsSoftware = value; }
        }

        private List<int> _selectedUnterstuetzungsSoftware;

        public List<int> SelectedUnterstuetzungsSoftware
        {
            get
            {
                if (_selectedUnterstuetzungsSoftware == null && Computer != null)
                {
                    _selectedUnterstuetzungsSoftware = Computer.Unterstuetzungssoftware.Select(m => m.Id).ToList();
                }

                return _selectedUnterstuetzungsSoftware;
            }
            set { _selectedUnterstuetzungsSoftware = value; }
        }
    }
}