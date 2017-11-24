using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WMS_CL.Manager
{
    public static class LagerManager
    {
        #region Properties
        public static List<Lager> MeineLager = new List<Lager>();
        public static List<Regal> MeineRegale = new List<Regal>();
        public static List<Ebene> MeineEbenen = new List<Ebene>();
        public static List<Produkt> MeineProdukte = new List<Produkt>();
        #endregion
        
        #region Lager
        public static Lager addLager (string LID, string Name, string Adress)
        {
            if (MeineLager.Exists((Lager l) => { return l.LID == LID; }))
                throw new Exception("Lager mit dieser ID bereits vergeben");

            Lager toAdd = new Lager(LID, Name, Adress);
            MeineLager.Add(toAdd);

            return toAdd;
        }

        public static Lager getLager(string LID)
        {
            return MeineLager.Find(x => x.LID == LID);
        }

        public static void updateLager()
        {

        }

        public static void deleteLager()
        {

        }
        #endregion

        #region Regal
        public static Regal addRegal(Lager MeinLager, string RID, int MaxEbene, List<Point> Position)
        {
            if (MeineRegale.Exists((Regal r) => { return r.RID == RID; }))
                throw new Exception("Regal mit dieser ID bereits vergeben");

            Regal toAdd = new Regal(MeinLager, RID, MaxEbene, Position);
            MeineRegale.Add(toAdd);

            return toAdd;
        }

        public static Regal getRegal(string RID)
        {
            return MeineRegale.Find(x => x.RID == RID);
        }

        public static void updateRegal()
        {

        }

        public static void deleteRegal()
        {

        }
        #endregion

        #region Ebene
        public static Ebene addEbene(Regal MeinRegal, string EID)
        {
            if (MeineEbenen.Exists((Ebene e) => { return e.EID == EID; }))
                throw new Exception("Ebene mit dieser ID bereits vergeben");

            Ebene toAdd = new Ebene(MeinRegal, EID);
            MeineEbenen.Add(toAdd);

            return toAdd;
        }

        public static Ebene getEbene(string EID)
        {
            return MeineEbenen.Find(x => x.EID == EID);
        }

        public static void updateEbene()
        {

        }

        public static void deleteEbene()
        {

        }
        #endregion

        #region Produkt
        public static Produkt addProdukt(string PID, string Name, int Menge, int PreisProEinheit, Ebene MeineEbene)
        {
            if (MeineProdukte.Exists((Produkt p) => { return p.PID == PID; }))
                throw new Exception("Produkt mit dieser ID bereits vergeben");

            Produkt toAdd = new Produkt(PID, Name, Menge, PreisProEinheit, MeineEbene);
            MeineProdukte.Add(toAdd);

            return toAdd;
        }

        public static Produkt getProdukt(string PID)
        {
            return MeineProdukte.Find(x => x.PID == PID);
        }

        public static void updateProdukt()
        {

        }

        public static void deleteProdukt()
        {

        }
        #endregion
    }
}
