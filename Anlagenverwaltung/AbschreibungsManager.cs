using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Anlagenverwaltung.Models;

namespace Anlagenverwaltung
{
    public class AbschreibungsManager
    {
        public decimal BerechneAfaProzent(int Nutzungsdauer)
        {
            if (Nutzungsdauer > 0)
            {
                return Decimal.Round(100 / Nutzungsdauer, 2);
            }

            return (decimal) 0.00;
        }

        public decimal BerechneAbschreibungssatzJahr(float anschaffungskosten, int nutzungsdauer)
        {
            if (nutzungsdauer > 0)
            {
                return Decimal.Round((decimal) (anschaffungskosten / nutzungsdauer), 2);
            }
            return (decimal)0.00;
        }

        public decimal BerechneBuchwert(DateTime vonDatum, DateTime bisDatum, int nutzungsdauer, float anschaffungskosten)
        {
            if (nutzungsdauer <= 0)
            {
                return (decimal) anschaffungskosten;
            }

            var months = bisDatum.Month -
                         vonDatum.Month +
                         (12 * (bisDatum.Year - vonDatum.Year));

            var nutzungsdauerInMonths = nutzungsdauer * 12;
            if (months > nutzungsdauerInMonths)
            {
                months = nutzungsdauerInMonths;
            }

            var abschreibungssatz = Decimal.Round((decimal) (anschaffungskosten / nutzungsdauer / 12), 2);
            var buchwert = anschaffungskosten;


            for (var i = 0; i < months; i++)
            {
                buchwert -= (float) abschreibungssatz;
            }
            buchwert = buchwert < 0 ? 0 : buchwert;
            return Decimal.Round((decimal) buchwert, 2);
        }
    }
}