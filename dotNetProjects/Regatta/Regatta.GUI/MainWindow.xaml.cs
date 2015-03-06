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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Regatta.Logik;

namespace Regatta.GUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private const string PathImages = "images/";
        private Dictionary<RegattaLogik.Windrichtung, BitmapImage> dictImages;

        public MainWindow()
        {
            BitmapImage imageWindrose;
            InitializeComponent();

            dictImages = new Dictionary<RegattaLogik.Windrichtung,BitmapImage>();

            imageWindrose = new BitmapImage(new Uri(PathImages + "wr" + RegattaLogik.Windrichtung.N + ".jpg", UriKind.Relative));
            dictImages.Add(RegattaLogik.Windrichtung.N, imageWindrose);
            imageWindrose = new BitmapImage(new Uri(PathImages + "wr" + RegattaLogik.Windrichtung.NO + ".jpg", UriKind.Relative));
            dictImages.Add(RegattaLogik.Windrichtung.NO, imageWindrose);
            imageWindrose = new BitmapImage(new Uri(PathImages + "wr" + RegattaLogik.Windrichtung.O + ".jpg", UriKind.Relative));
            dictImages.Add(RegattaLogik.Windrichtung.O, imageWindrose);
            imageWindrose = new BitmapImage(new Uri(PathImages + "wr" + RegattaLogik.Windrichtung.SO + ".jpg", UriKind.Relative));
            dictImages.Add(RegattaLogik.Windrichtung.SO, imageWindrose);
            imageWindrose = new BitmapImage(new Uri(PathImages + "wr" + RegattaLogik.Windrichtung.S + ".jpg", UriKind.Relative));
            dictImages.Add(RegattaLogik.Windrichtung.S, imageWindrose);
            imageWindrose = new BitmapImage(new Uri(PathImages + "wr" + RegattaLogik.Windrichtung.SW + ".jpg", UriKind.Relative));
            dictImages.Add(RegattaLogik.Windrichtung.SW, imageWindrose);
            imageWindrose = new BitmapImage(new Uri(PathImages + "wr" + RegattaLogik.Windrichtung.W + ".jpg", UriKind.Relative));
            dictImages.Add(RegattaLogik.Windrichtung.W, imageWindrose);
            imageWindrose = new BitmapImage(new Uri(PathImages + "wr" + RegattaLogik.Windrichtung.NW + ".jpg", UriKind.Relative));
            dictImages.Add(RegattaLogik.Windrichtung.NW, imageWindrose);

            for (int i = 0; i < 50; i++)
            {
                regattaGrid.RowDefinitions.Add(new RowDefinition());
                regattaGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            drawStatus();
            drawGrid();
        }

        private void drawStatus()
        {

        }

        private void drawGrid()
        {
            Label lblCell;
            SolidColorBrush brushRed = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            SolidColorBrush brushWhite = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            for (int x = 1; x < regattaGrid.ColumnDefinitions.Count; x++)
            {
                for (int y = 1; y < regattaGrid.RowDefinitions.Count; y++)
                {
                    try
                    {
                        lblCell = new Label();
                        lblCell.BorderThickness = new Thickness(1);
                        lblCell.BorderBrush = Brushes.Gray;

                        Grid.SetColumn(lblCell, x);
                        Grid.SetRow(lblCell, y);
                        regattaGrid.Children.Add(lblCell);
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
            }
        }


    }
}
