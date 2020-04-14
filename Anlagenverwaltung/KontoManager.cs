using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Anlagenverwaltung.Models;

namespace Anlagenverwaltung
{
    public class KontoManager
    {
        private const int kontoNrAnteilAO = 500;
        private const int kontoNrAusstattung = 410;
        private const int kontoNrBueroeinrichtung = 420;
        private const int kontoNrPkw = 320;
        private const int kontoNrSoftware = 27;

        private int lastDetailedKontoNrOfAllAbschreibungen;
        private int lastGeschaeftsausstattung;
        private int lastEDV;
        private int lastBuero;
        private int lastPKW;
        private int lastAO;

        public int KontoNrAnteilAO { get { return kontoNrAnteilAO; } }
        public int KontoNrAusstattung { get { return kontoNrAusstattung; } }
        public int KontoNrBueroeinrichtung { get { return kontoNrBueroeinrichtung; } }
        public int KontoNrPkw { get { return kontoNrPkw; } }
        public int KontoNrSoftware { get { return kontoNrSoftware; } }


        public int GetNewDetailedKontoNr(ApplicationDbContext dbContext, int kontoNr)
        {

            var allAbschreibungen =
                    dbContext.Abschreibungen.Where(c => c.KontoNr.ToString().Substring(0, 3).Contains(kontoNr.ToString())).ToList();

            if (allAbschreibungen.Count > 0)
            {
                lastDetailedKontoNrOfAllAbschreibungen = allAbschreibungen[allAbschreibungen.Count - 1].KontoNr;
                lastDetailedKontoNrOfAllAbschreibungen += 1;
                return lastDetailedKontoNrOfAllAbschreibungen;
            }
            else
            {
                return int.Parse(kontoNr.ToString() + "001");
            }

        }

        public int GetNewUnknownDetailedKontoNr(ApplicationDbContext dbContext, int shortKontoNr)
        {
            switch (shortKontoNr)
            {
                case kontoNrAnteilAO:
                    if (lastAO == 0)
                    {
                        var allAOAbschreibungen  = 
                            dbContext.Abschreibungen.Where(c => c.KontoNr.ToString().Substring(0, 3).Contains(kontoNrAnteilAO.ToString())).ToList();

                        if (allAOAbschreibungen.Count > 0)
                        {
                            lastAO = allAOAbschreibungen[allAOAbschreibungen.Count - 1].KontoNr;
                            lastAO += 1;
                        }
                        else
                        {
                            lastAO = int.Parse(kontoNrAnteilAO.ToString() + "001");
                        }
                    }
                    else
                    {
                        lastAO += 1;
                    }

                    return lastAO;

                case kontoNrAusstattung:
                    if (lastGeschaeftsausstattung == 0)
                    {
                        var allGeschaeftsAusstattungAbschreibungen =
                            dbContext.Abschreibungen.Where(c => c.KontoNr.ToString().Substring(0, 3).Contains(kontoNrAusstattung.ToString())).ToList();

                        if (allGeschaeftsAusstattungAbschreibungen.Count > 0)
                        {
                            lastGeschaeftsausstattung = allGeschaeftsAusstattungAbschreibungen[allGeschaeftsAusstattungAbschreibungen.Count - 1].KontoNr;
                            lastGeschaeftsausstattung += 1;
                        }
                        else
                        {
                            lastGeschaeftsausstattung = int.Parse(kontoNrAusstattung.ToString() + "001");
                        }
                    }
                    else
                    {
                        lastGeschaeftsausstattung += 1;
                    }

                    return lastGeschaeftsausstattung;

                case kontoNrBueroeinrichtung:
                    if (lastBuero == 0)
                    {
                        var allBueroAbschreibungen =
                            dbContext.Abschreibungen.Where(c => c.KontoNr.ToString().Substring(0, 3).Contains(kontoNrBueroeinrichtung.ToString())).ToList();

                        if (allBueroAbschreibungen.Count > 0)
                        {
                            lastBuero = allBueroAbschreibungen[allBueroAbschreibungen.Count - 1].KontoNr;
                            lastBuero += 1;
                        }
                        else
                        {
                            lastBuero = int.Parse(kontoNrBueroeinrichtung.ToString() + "001");
                        }
                    }
                    else
                    {
                        lastBuero += 1;
                    }

                    return lastBuero;

                case kontoNrPkw:
                    if (lastPKW == 0)
                    {
                        var allPkwAbschreibungen =
                            dbContext.Abschreibungen.Where(c => c.KontoNr.ToString().Substring(0, 3).Contains(kontoNrPkw.ToString())).ToList();

                        if (allPkwAbschreibungen.Count > 0)
                        {
                            lastPKW = allPkwAbschreibungen[allPkwAbschreibungen.Count - 1].KontoNr;
                            lastPKW += 1;
                        }
                        else
                        {
                            lastPKW = int.Parse(kontoNrPkw.ToString() + "001");
                        }
                    }
                    else
                    {
                        lastPKW += 1;
                    }

                    return lastPKW;

                case kontoNrSoftware:
                    if (lastEDV == 0)
                    {
                        var allEdvAbschreibungen =
                            dbContext.Abschreibungen.Where(c => c.KontoNr.ToString().Substring(0, 3).Contains(kontoNrSoftware.ToString())).ToList();

                        if (allEdvAbschreibungen.Count > 0)
                        {
                            lastEDV = allEdvAbschreibungen[allEdvAbschreibungen.Count - 1].KontoNr;
                            lastEDV += 1;
                        }
                        else
                        {
                            lastEDV = int.Parse(kontoNrSoftware.ToString() + "001");
                        }
                    }
                    else
                    {
                        lastEDV += 1;
                    }

                    return lastEDV;

                default:
                    return 0;

            }

        }
    }
}