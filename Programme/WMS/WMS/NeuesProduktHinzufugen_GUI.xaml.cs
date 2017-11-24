using System;
using System.Windows;
using WMS_CL;
using WMS_CL.Manager;

namespace WMS
{
    /// <summary>
    /// Interaktionslogik für NeuesProduktHinzufugen.xaml
    /// </summary>
    public partial class NeuesProduktHinzufugen_GUI : Window
    {
        public NeuesProduktHinzufugen_GUI()
        {
            InitializeComponent();

            fillComboBoxes();
        }

        private void fillComboBoxes()
        {
            cb_Lager.Items.Clear();
            cb_Regal.Items.Clear();
            cb_Ebene.Items.Clear();

            foreach(Lager v in LagerManager.MeineLager)
                cb_Lager.Items.Add(v);

            foreach (Regal v in LagerManager.MeineRegale)
                cb_Regal.Items.Add(v);

            foreach (Ebene v in LagerManager.MeineEbenen)
                cb_Ebene.Items.Add(v);

            cb_Lager.SelectedItem = cb_Lager.Items[0];
            cb_Regal.SelectedItem = cb_Regal.Items[0];
            cb_Ebene.SelectedItem = cb_Ebene.Items[0];
        }

        private void bttn_Hinzufugen_Click(object sender, RoutedEventArgs e)
        {
            string name = "";
            int menge = 0, preisProEinheit = 0;
            Ebene ebene = null;

            try
            {
                name = tb_Name.Text;
                menge = int.Parse(tb_Menge.Text);
                preisProEinheit = int.Parse(tb_PreisProEinheit.Text);
                ebene = (Ebene) cb_Ebene.SelectedItem;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Fehler bei der Eingabe. Fehlermeldung: " + ex.Message);
            }

            try
            {
                Produkt p = LagerManager.addProdukt("P" + ProduktIDGenerator.ID, name, menge, preisProEinheit, ebene);

                MyDatabase.Connect(true);
                MyDatabase.insertValuesIntoProdukt(p);
                MyDatabase.Commit();
                MyDatabase.Close();

                MessageBox.Show("Produkt hinzugefügt.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Hinzufügen. Fehlermeldung: " + ex.Message);
            }
        }
    }
}
