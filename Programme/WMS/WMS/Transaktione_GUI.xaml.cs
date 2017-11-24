using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WMS_CL.Manager;

namespace WMS
{
    /// <summary>
    /// Interaktionslogik für Transaktione_GUI.xaml
    /// </summary>
    public partial class Transaktione_GUI : Window
    {
        public Transaktione_GUI()
        {
            InitializeComponent();

            dg_Einlagern.ItemsSource = Ein_AuslagernManager.MeinEinlagern;
            dg_Auslagern.ItemsSource = Ein_AuslagernManager.MeinAuslagern;
        }

        private void tb_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!tb_Search.Text.Contains("Search"))
            {
                var ObColl = new ObservableCollection<Einlagern>(Ein_AuslagernManager.MeinEinlagern);
                var _itemSourceList = new CollectionViewSource() { Source = ObColl };
                ICollectionView Itemlist = _itemSourceList.View;
                var yourCostumFilter = new Predicate<object>(item => ((Einlagern)item).am.ToString().Contains(tb_Search.Text));
                Itemlist.Filter = yourCostumFilter;

                dg_Einlagern.ItemsSource = Itemlist;
            }
        }

        private void tb_SearchAus_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!tb_Search.Text.Contains("Search"))
            {
                var ObColl = new ObservableCollection<Auslagern>(Ein_AuslagernManager.MeinAuslagern);
                var _itemSourceList = new CollectionViewSource() { Source = ObColl };
                ICollectionView Itemlist = _itemSourceList.View;
                var yourCostumFilter = new Predicate<object>(item => ((Auslagern)item).am.ToString().Contains(tb_SearchAus.Text));
                Itemlist.Filter = yourCostumFilter;

                dg_Auslagern.ItemsSource = Itemlist;
            }
        }
    }
}
