using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS_CL.Manager
{
    public static class Ein_AuslagernManager
    {
        public static List<Auslagern> MeinAuslagern = new List<Auslagern>();
        public static List<Einlagern> MeinEinlagern = new List<Einlagern>();

        #region Auslagern
        public static Auslagern addAuslagern(DateTime am, Benutzer meinBenutzer, Produkt meinProdukt, int menge, int preis)
        {
            if (MeinAuslagern.Exists((Auslagern a) => { return a.am == am && a.MeinBenutzer == meinBenutzer && a.MeinProdukt == meinProdukt; }))
                throw new Exception("Auslagern mit dieser ID bereits vergeben");

            Auslagern toAdd = new Auslagern(am, menge, preis, meinProdukt, meinBenutzer);
            MeinAuslagern.Add(toAdd);

            return toAdd;
        }

        public static Auslagern getAuslagern(DateTime am, Benutzer meinBenutzer, Produkt meinProdukt)
        {
            return MeinAuslagern.Find(x => x.am == am && x.MeinBenutzer == meinBenutzer && x.MeinProdukt == meinProdukt);
        }
        #endregion

        #region Einlagern
        public static Einlagern addEinlagern(DateTime am, Benutzer meinBenutzer, Produkt meinProdukt, int menge, int preis)
        {
            if (MeinAuslagern.Exists((Auslagern a) => { return a.am == am && a.MeinBenutzer == meinBenutzer && a.MeinProdukt == meinProdukt; }))
                throw new Exception("Auslagern mit dieser ID bereits vergeben");

            Einlagern toAdd = new Einlagern(am, menge, preis, meinProdukt, meinBenutzer);
            MeinEinlagern.Add(toAdd);

            return toAdd;
        }

        public static Einlagern getEinlagern(DateTime am, Benutzer meinBenutzer, Produkt meinProdukt)
        {
            return MeinEinlagern.Find(x => x.am == am && x.MeinBenutzer == meinBenutzer && x.MeinProdukt == meinProdukt);
        }
        #endregion
    }
}
