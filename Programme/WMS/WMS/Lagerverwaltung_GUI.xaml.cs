using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;
using WMS_CL;
using WMS_CL.Manager;

namespace WMS
{
    /// <summary>
    /// Interaktionslogik für Lagerverwaltung_GUI.xaml
    /// </summary>
    public partial class Lagerverwaltung_GUI : Window
    {
        public Lagerverwaltung_GUI()
        {
            // Initialize
            InitializeComponent();
            
            // Set Data
            dg_Products.ItemsSource = LagerManager.MeineProdukte;
        }

  
        private void tb_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_Search.Text != "Search")
            {
                var ObColl = new ObservableCollection<Produkt>(LagerManager.MeineProdukte);
                var _itemSourceList = new CollectionViewSource() { Source = ObColl };
                ICollectionView Itemlist = _itemSourceList.View;
                var yourCostumFilter = new Predicate<object>(item => ((Produkt)item).Name.Contains(tb_Search.Text));
                Itemlist.Filter = yourCostumFilter;

                dg_Products.ItemsSource = Itemlist;
            }
        }
    }
}
