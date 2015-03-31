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

        private RegattaViewModel _vm;

        public MainWindow()
        {
           
            InitializeComponent();
            
            _vm = new RegattaViewModel();
            this.DataContext = _vm;

            

            for (int i = 0; i < _vm.MaxReihen; i++)
            {
                regattaGrid.RowDefinitions.Add(new RowDefinition());
                regattaGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            drawStatus();
            drawGrid();
            drawYachten(_vm.Yachten);
        }

        private void drawYachten(List<Yacht> Yachten)
        {
            foreach (var yacht in Yachten)
	        {
                regattaGrid.ColumnDefinitions.ElementAt(yacht.Pos.X);
	        }
            
        }

        private void drawStatus()
        {
           // WindroseImage();
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



        private void btnWindroseLinks_Click(object sender, RoutedEventArgs e)
        {
            _vm.WinrdoseLinks();
        }

        private void btnWindroseRechts_Click(object sender, RoutedEventArgs e)
        {
            _vm.WinrdoseRechts();
        }

    }
}
