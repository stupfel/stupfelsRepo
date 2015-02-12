﻿using System;
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

namespace TastaturSteuerung
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            double top = (double)rc.GetValue(Canvas.TopProperty);
            double left = (double)rc.GetValue(Canvas.LeftProperty);

            switch (e.Key)
            {
                  
                case Key.W:
                    rc.SetValue(Canvas.TopProperty, top - 5); break;
                case Key.S:
                    rc.SetValue(Canvas.TopProperty, top + 5); break;
                case Key.A:
                    rc.SetValue(Canvas.LeftProperty, left - 5); break;
                case Key.D:
                    rc.SetValue(Canvas.LeftProperty, left + 5); break;
            }
            rc.Fill = new SolidColorBrush(Colors.LightGray);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            rc.Fill = new SolidColorBrush(Colors.Gray);
        }
    }
}
