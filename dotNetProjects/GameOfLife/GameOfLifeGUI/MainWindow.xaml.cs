using GameOfLife;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace GameOfLifeGUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CellBlock Cells;
        SortedList<long, Label> listLabels;
        
        public MainWindow()
        {
            InitializeComponent();
            // Grid anpassen
            for (int i = 0; i < 50; i++)
            {
                golGrid.RowDefinitions.Add(new RowDefinition());
                golGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }




                //e = new Ellipse();
                //e.Fill = brush;
                //e.StrokeThickness = 2;
                //e.Stroke = Brushes.Black;

                //e.Width = 30;
                //e.Height = 30;

                //c1.Children.Add(e);

            listLabels = new SortedList<long, Label>();
            Cells = new CellBlock();
            Cells.createRandomState();
            CreateCells();
            

            
        }

        private void CreateCells()
        {
            Label lblCell;
            Cell currentCell;
            SolidColorBrush brushRed = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            SolidColorBrush brushWhite = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            
            for (int x = 1; x < Cells.getXMax(); x++)
            {
                for (int y = 1; y < Cells.getYMax(); y++)
                {
                    try
                    {
                        lblCell = new Label();
                        currentCell = Cells.getCell(x, y);

                        lblCell.BorderThickness = new Thickness(1);
                        lblCell.BorderBrush = Brushes.Gray;

                        if (currentCell.Alive)
                        {
                            lblCell.Background = brushRed;
                        }
                        else
                        {
                            lblCell.Background = brushWhite;
                        }
     
                        Grid.SetColumn(lblCell, x);
                        Grid.SetRow(lblCell, y);
                        golGrid.Children.Add(lblCell);
                        listLabels.Add(currentCell.id, lblCell);

                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
            }
        }

        private void DrawCells()
        {
            Debug.Print("DrawCells");
            try
            {
                Label lblCell;
                Cell currentCell;
                for (int x = 1; x < Cells.getXMax(); x++)
                {
                    for (int y = 1; y < Cells.getYMax(); y++)
                    {
                        currentCell = Cells.getCell(x, y);
                        if (currentCell.Alive)
                        {
                            if (listLabels.TryGetValue(currentCell.id, out lblCell))
                            {
                                lblCell.Background = Brushes.Red;
                            }
                        }
                        else
                        {
                            if (listLabels.TryGetValue(currentCell.id, out lblCell))
                            {
                                lblCell.Background = Brushes.White;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            
            Cells.checkNextStates(false);
            Cells.UpdateNextStates();
            DrawCells();
        }

        private void checkAuto_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)checkAuto.IsChecked)
            {
                for (int i = 0; i < 1000; i++)
                {
                    Cells.checkNextStates(false);
                    Cells.UpdateNextStates();
                    DrawCells();
                }
            }
        }
    }
}
