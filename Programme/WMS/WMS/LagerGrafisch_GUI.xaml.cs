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
using WMS_CL.Manager;

namespace WMS
{
    /// <summary>
    /// Interaktionslogik für LagerGrafisch_GUI.xaml
    /// </summary>
    public partial class LagerGrafisch_GUI : Window
    {
        public LagerGrafisch_GUI()
        {
            InitializeComponent();
            zeichneRegale();
        }

        private void zeichneRegale()
        {
            for (int j = 0; j < LagerManager.MeineRegale.Count; j++)
            {
                Regal currentRegal = LagerManager.MeineRegale.ElementAt(j);
                Polygon p = new Polygon();
                p.Points = new PointCollection();
                p.MouseDown += (sender, e) => rectangle_clicked(sender, e, currentRegal);

                for (int i = 0; i < currentRegal.Position.Count - 1; i++)
                {
                    p.Points.Add(new Point(currentRegal.Position.ElementAt(i).X,
                        cs_LagerDarstellung.Height - currentRegal.Position.ElementAt(i).Y));
                }

                drawPolygon(p, 2);
            }
        }

        private void drawPolygon(Polygon polygon, int strokeThickness)
        {
            polygon.Stroke = Brushes.Black;
            polygon.StrokeThickness = 1;
            polygon.Fill = Brushes.LightBlue;
            
            polygon.HorizontalAlignment = HorizontalAlignment.Left;
            polygon.VerticalAlignment = VerticalAlignment.Center;

            cs_LagerDarstellung.Children.Add(polygon);
        }

        private void rectangle_clicked(object sender, MouseButtonEventArgs e, Regal r)
        {
            updateRegalInhalt(r);
            lbl_Ausgabe.Content = "Sie sehen " + r;
        }
         
        private void updateRegalInhalt(Regal r)
        {
            lb_RegalInhalt.Items.Clear();
            foreach (Produkt p in LagerManager.MeineProdukte)
            {
                if(p.PID.Remove(5) == r.RID)
                    lb_RegalInhalt.Items.Add(p);
            }
        }
    }
}
