using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WMS_CL;
using WMS_CL.Manager;

namespace WMS
{
    /// <summary>
    /// Interaktionslogik für Kaufen_GUI.xaml
    /// </summary>
    public partial class Kaufen_GUI : Window
    {
        public Kaufen_GUI()
        {
            InitializeComponent();
            fillData();
        }

        private void fillData()
        {
            cb_Lager.Items.Clear();
            cb_Regal.Items.Clear();
            cb_Ebene.Items.Clear();
            cb_Produkt.Items.Clear();

            foreach (var l in LagerManager.MeineLager)
            {
                cb_Lager.Items.Add(l);
            }

            foreach (var l in LagerManager.MeineRegale)
            {
                cb_Regal.Items.Add(l);
            }


            foreach (var l in LagerManager.MeineEbenen)
            {
                cb_Ebene.Items.Add(l);
            }

            foreach (var l in LagerManager.MeineProdukte)
            {
                cb_Produkt.Items.Add(l);
            }

            cb_Lager.SelectedItem = cb_Lager.Items[0];
            cb_Regal.SelectedItem = cb_Regal.Items[0];
            cb_Ebene.SelectedItem = cb_Ebene.Items[0];
            cb_Produkt.SelectedItem = cb_Produkt.Items[0];
        }

        private void tb_Menge_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                lbl_Preis.Content = double.Parse(tb_Menge.Text) * double.Parse(tb_Preis.Text);
            }
            catch { }
        }

        private void bttn_Auslagern_Click(object sender, RoutedEventArgs e)
        {
            Auslagern a = Ein_AuslagernManager.addAuslagern(DateTime.Now, MainWindow.eingeloggterBenutzer, (Produkt)cb_Produkt.SelectedItem,
                int.Parse(tb_Menge.Text), int.Parse(tb_Preis.Text));

            MyDatabase.Connect(true);

            if(MyDatabase.InsertIntoAuslagern(a) > 0)
                MessageBox.Show("Auslagern erfolgreich. " + a.am);
            else
                MessageBox.Show("Auslagern fehlgeschlagen.");

            MyDatabase.Commit();
            MyDatabase.Close();

            ((Produkt)cb_Produkt.SelectedItem).Menge -= int.Parse(tb_Menge.Text);
            

            // Update Menge
            lbl_MaxMenge.Content = ((Produkt)cb_Produkt.SelectedItem).Menge;
        }

        private void cb_Produkt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbl_MaxMenge.Content = ((Produkt)cb_Produkt.SelectedItem).Menge;
            tb_Preis.Text = ((Produkt)cb_Produkt.SelectedItem).PreisProEinheit.ToString();

            try
            {
                if(double.Parse(tb_Menge.Text) > ((Produkt)cb_Produkt.SelectedItem).Menge)
                    tb_Menge.Text = ((Produkt)cb_Produkt.SelectedItem).Menge.ToString();
            }
            catch { }
        }
    }
}
