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
using System.Windows.Threading;

namespace BSS_B
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.MouseMove -= _MouseMove;

            Random rnd = new Random();
            MyEllipse.Margin = new Thickness(rnd.Next((int)Width - (int)MyEllipse.Width), rnd.Next((int)Height - (int)MyEllipse.Height), 0, 0);
            movePosition = rnd.Next(4) * 2 + 1;
            color = Color.FromRgb((byte)rnd.Next(255), (byte)rnd.Next(255), (byte)rnd.Next(255)); //Zufällige Startfarbe ermitteln 

            colorTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            colorTimer.Tick += new EventHandler(colorTimer_Tick);
            colorTimer.Start();

            moveTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            moveTimer.Tick += new EventHandler(moveTimer_Tick);
            moveTimer.Start();

            Mouse.OverrideCursor = Cursors.None;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void _MouseMove(object sender, MouseEventArgs e)
        {
            //Close();
            this.Visibility = Visibility.Hidden;
            
        }
        private void _KeyDown(object sender, KeyEventArgs e)
        {
           // Close();
            this.Visibility = Visibility.Visible;
        }

        #region Farbveränderung

        DispatcherTimer colorTimer = new DispatcherTimer();
        Color color = new Color();
        bool r, g, b; //false = MAX_COLOR > MIN_COLOR 

        static int MIN_COLOR = 0;
        static int MAX_COLOR = 255;

        private void colorTimer_Tick(object sender, EventArgs e)
        {
            MyEllipse.Fill = new SolidColorBrush(color);

            #region Farbgrenzen erreicht

            if (color.R >= MAX_COLOR)
            {
                r = false;
            }
            if (color.R <= MIN_COLOR)
            {
                r = true;
            }
            if (color.G >= MAX_COLOR)
            {
                g = false;
            }
            if (color.G <= MIN_COLOR)
            {
                g = true;
            }
            if (color.B >= MAX_COLOR)
            {
                b = false;
            }
            if (color.B <= MIN_COLOR)
            {
                b = true;
            }

            #endregion

            #region Farben verändern

            if (r)
            {
                ++color.R;
            }
            else
            {
                --color.R;
            }
            if (g)
            {
                ++color.G;
            }
            else
            {
                --color.G;
            }
            if (b)
            {
                ++color.B;
            }
            else
            {
                --color.B;
            }

            #endregion
        }

        #endregion

        #region Bewegung

        DispatcherTimer moveTimer = new DispatcherTimer();
        int movePosition = 5;
        //   1 2 3 
        //   8   4 
        //   7 6 5 

        private void moveTimer_Tick(object sender, EventArgs e)
        {
            this.MouseMove += _MouseMove;

            switch (movePosition)
            {
                case 1:
                    MyEllipse.Margin = new Thickness(MyEllipse.Margin.Left - 1, MyEllipse.Margin.Top - 1, MyEllipse.Margin.Right + 1, MyEllipse.Margin.Bottom + 1);
                    break;
                case 2:
                    MyEllipse.Margin = new Thickness(MyEllipse.Margin.Left, MyEllipse.Margin.Top - 1, MyEllipse.Margin.Right, MyEllipse.Margin.Bottom + 1);
                    break;
                case 3:
                    MyEllipse.Margin = new Thickness(MyEllipse.Margin.Left + 1, MyEllipse.Margin.Top - 1, MyEllipse.Margin.Right - 1, MyEllipse.Margin.Bottom + 1);
                    break;
                case 4:
                    MyEllipse.Margin = new Thickness(MyEllipse.Margin.Left + 1, MyEllipse.Margin.Top, MyEllipse.Margin.Right - 1, MyEllipse.Margin.Bottom);
                    break;
                case 5:
                    MyEllipse.Margin = new Thickness(MyEllipse.Margin.Left + 1, MyEllipse.Margin.Top + 1, MyEllipse.Margin.Right - 1, MyEllipse.Margin.Bottom - 1);
                    break;
                case 6:
                    MyEllipse.Margin = new Thickness(MyEllipse.Margin.Left, MyEllipse.Margin.Top + 1, MyEllipse.Margin.Right, MyEllipse.Margin.Bottom - 1);
                    break;
                case 7:
                    MyEllipse.Margin = new Thickness(MyEllipse.Margin.Left - 1, MyEllipse.Margin.Top + 1, MyEllipse.Margin.Right + 1, MyEllipse.Margin.Bottom - 1);
                    break;
                case 8:
                    MyEllipse.Margin = new Thickness(MyEllipse.Margin.Left - 1, MyEllipse.Margin.Top, MyEllipse.Margin.Right + 1, MyEllipse.Margin.Bottom);
                    break;
            }

            if (MyEllipse.Margin.Left <= 0 && MyEllipse.Margin.Top <= 0)
            {
                movePosition = 5;
            }
            else if (MyEllipse.Margin.Left > 0 && MyEllipse.Margin.Left + MyEllipse.Width < Width && MyEllipse.Margin.Top <= 0)
            {
                if (movePosition == 1)
                {
                    movePosition = 7;
                }
                else
                {
                    movePosition = 5;
                }
            }
            else if (MyEllipse.Margin.Top <= 0 && MyEllipse.Margin.Left + MyEllipse.Width > Width)
            {
                movePosition = 7;
            }
            else if (MyEllipse.Margin.Top > 0 && MyEllipse.Margin.Top + MyEllipse.Height < Height && MyEllipse.Margin.Left + MyEllipse.Width > Width)
            {
                if (movePosition == 5)
                {
                    movePosition = 7;
                }
                else
                {
                    movePosition = 1;
                }
            }
            else if (MyEllipse.Margin.Left + MyEllipse.Width > Width && MyEllipse.Margin.Top + MyEllipse.Height > Height)
            {
                movePosition = 1;
            }
            else if (MyEllipse.Margin.Left + MyEllipse.Width < Width && MyEllipse.Margin.Left > 0 && MyEllipse.Margin.Top + MyEllipse.Height > Height)
            {
                if (movePosition == 7)
                {
                    movePosition = 1;
                }
                else
                {
                    movePosition = 3;
                }
            }
            else if (MyEllipse.Margin.Left <= 0 && MyEllipse.Margin.Top + MyEllipse.Height > Height)
            {
                movePosition = 3;
            }
            else if (MyEllipse.Margin.Top > 0 && MyEllipse.Margin.Top + MyEllipse.Height < Height && MyEllipse.Margin.Left <= 0)
            {
                if (movePosition == 7)
                {
                    movePosition = 5;
                }
                else
                {
                    movePosition = 3;
                }
            }
        }

        #endregion

    }
}
