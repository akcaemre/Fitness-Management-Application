using System;
using System.Collections.Generic;

namespace WMS_CL.Manager
{
    public static class Benutzermanager
    {
        public static List<Benutzer> MeineBenutzer = new List<Benutzer>();

        public static void addBenutzer(string eMail)
        {
            if (benutzerExists(eMail))
                throw new Exception("Ein anderer Nutzer hat diese E-Mail bereits!");

            MeineBenutzer.Add(new Benutzer(eMail));
            
        }

        public static Benutzer getBenutzer (string eMail)
        {
            return MeineBenutzer.Find(x => x.eMail.Equals(eMail));
        }

        public static void updateBenutzer (string eMail, Benutzer newBenutzer)
        {
            if (eMail != newBenutzer.eMail && benutzerExists(newBenutzer.eMail))
                throw new Exception("Ein anderer Nutzer hat diese E-Mail bereits!");

            Benutzer toUpdate = MeineBenutzer.Find(x => x.eMail.Equals(eMail));
            toUpdate = newBenutzer;
        }

        public static void deleteBenutzer(Benutzer benutzerToDelete)
        {
            if (!benutzerExists(benutzerToDelete.eMail))
                throw new Exception("Benutzer existiert nicht.");

            MeineBenutzer.Remove(benutzerToDelete);
        }

        public static void deleteBenutzer(string eMail)
        {
            if (!benutzerExists(eMail))
                throw new Exception("Benutzer existiert nicht.");

            MeineBenutzer.Remove(getBenutzer(eMail));
        }

        private static bool benutzerExists(string eMail)
        {
            return MeineBenutzer.Exists(x => x.eMail.Equals(eMail));
        }
    }
}
