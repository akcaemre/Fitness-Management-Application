using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WMS_CL;
using WMS_CL.Manager;

namespace WMS
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Benutzer eingeloggterBenutzer;
        public MainWindow()
        {
            InitializeComponent();
            
            // Fill Data
            MyDatabase.Connect(true);
            fillData();
            MyDatabase.Close(); 
        }

        #region Database Functions
        private void fillData()
        {
            fillBenutzer();
            fillLager();
            fillRegale();
            fillEbenen();
            fillProdukte();
            fillEinlagern();
            fillAuslagern();
        }

        private void fillEinlagern()
        {
            IDataReader idr = MyDatabase.GetEinlagernReader();

            while (idr.Read())
            {
                Einlagern e = new Einlagern(DateTime.Parse(idr[0].ToString()), int.Parse(idr[1].ToString()), int.Parse(idr[2].ToString()), 
                    LagerManager.getProdukt(idr[4].ToString()),
                    Benutzermanager.getBenutzer(idr[3].ToString()));

                Ein_AuslagernManager.MeinEinlagern.Add(e);
            }
        }

        private void fillAuslagern()
        {
            IDataReader idr = MyDatabase.GetAuslagernReader();

            while (idr.Read())
            {
                Auslagern a = new Auslagern(DateTime.Parse(idr[0].ToString()), int.Parse(idr[1].ToString()), int.Parse(idr[2].ToString()),
                    LagerManager.getProdukt(idr[4].ToString()),
                    Benutzermanager.getBenutzer(idr[3].ToString()));

                Ein_AuslagernManager.MeinAuslagern.Add(a);
            }
        }

        private void fillBenutzer()
        {
            IDataReader idr = MyDatabase.GetBenutzerReader();

            while (idr.Read())
            {
                Benutzer b = new Benutzer(idr[0].ToString());
                Benutzermanager.addBenutzer(b.eMail);
                cb_Benutzer.Items.Add(b);
            }

            cb_Benutzer.SelectedItem = cb_Benutzer.Items[0];
        }

        private void fillProdukte()
        {
            IDataReader idr = MyDatabase.GetProduktReader();
            while (idr.Read())
            {
                string[] splitted = idr[0].ToString().Split('-');
                string name = idr[1].ToString();
                int Menge = int.Parse(idr[2].ToString()), PreisProEinheit = int.Parse(idr[3].ToString());

                LagerManager.addProdukt(splitted[3], name, Menge, PreisProEinheit, LagerManager.getEbene(splitted[0] + "-" + splitted[1] + "-" + splitted[2]));
            }
        }

        private void fillEbenen()
        {
            IDataReader idr = MyDatabase.GetEbeneReader();
            while (idr.Read())
            {
                string[] splitted = idr[0].ToString().Split('-');

                LagerManager.addEbene(LagerManager.getRegal(splitted[0] + "-" + splitted[1]), splitted[2]);
            }
        }

        private void fillRegale()
        {
            IDataReader idr = MyDatabase.GetRegalReader();
            while (idr.Read())
            {
                string[] splitted = null;
                int maxEbene = 0, x = 0, y = 0;

                for (int i = 0; i < idr.FieldCount; i++)
                {
                    if (i == 0)
                        splitted = idr[i].ToString().Split('-');
                    else if (i == 1)
                        maxEbene = int.Parse(idr[i].ToString());
                    else if (i == 2)
                        x = int.Parse(idr[i].ToString());
                    else if (i == 3)
                        y = int.Parse(idr[i].ToString());
                }

                if (LagerManager.getRegal(splitted[0] + "-" + splitted[1]) == null)
                    LagerManager.addRegal(LagerManager.getLager(splitted[0]), splitted[1], maxEbene, new List<Point> { new Point(x, y) });
                else
                    LagerManager.getRegal(splitted[0] + "-" + splitted[1]).Position.Add(new Point(x, y));
            }
        }

        private void fillLager()
        {
            IDataReader idr = MyDatabase.GetLagerReader();
            while (idr.Read())
            {
                string lid = "", name = "", adress = "";

                for (int i = 0; i < idr.FieldCount; i++)
                {
                    if (i == 0)
                    {
                        lid = idr[i].ToString();
                    }
                    else if (i == 1)
                    {
                        name = idr[i].ToString();
                    }
                    else if (i == 2)
                    {
                        adress = idr[i].ToString();
                    }
                }

                LagerManager.addLager(lid, name, adress);
            }
        }

        #endregion
        private void bttn_LagerVerwaltung_Click(object sender, RoutedEventArgs e)
        {
            Lagerverwaltung_GUI lvg = new Lagerverwaltung_GUI();
            lvg.Show();
        }

        private void bttn_NeuesProdukt_Click(object sender, RoutedEventArgs e)
        {
            NeuesProduktHinzufugen_GUI nph = new NeuesProduktHinzufugen_GUI();
            nph.Show();
        }

        private void bttn_LagerGrafisch_Click(object sender, RoutedEventArgs e)
        {
            LagerGrafisch_GUI lgg = new LagerGrafisch_GUI();
            lgg.Show();
        }

        private void bttn_Kaufen_Click(object sender, RoutedEventArgs e)
        {
            Kaufen_GUI kg = new Kaufen_GUI();
            kg.Show();
        }

        private void btn_Verkaufen_Click(object sender, RoutedEventArgs e)
        {
            Verkaufen_GUI vkg = new Verkaufen_GUI();
            vkg.Show();
        }

        private void cb_Benutzer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            eingeloggterBenutzer = (Benutzer) cb_Benutzer.SelectedItem;
        }

        private void bttn_Transaktione_Click(object sender, RoutedEventArgs e)
        {
            Transaktione_GUI tg = new Transaktione_GUI();
            tg.Show();
        }
    }
}
