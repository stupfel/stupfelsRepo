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

namespace ControlsGestaltung
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

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            Button b1 = e.Source as Button;
            b1.Height = 23;
            b1.Width = 220;
            b1.FontFamily = new FontFamily("Comic Sans MS");
            b1.FontSize = 12;
            b1.FontStyle = FontStyles.Normal;
            b1.FontWeight = FontWeights.Normal;
            b1.Content = "1: H23, W220, Comic Sans MS 12";
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            Button b3 = sender as Button;
            b3.Background = new SolidColorBrush(Colors.Gray);
            b3.Foreground = new SolidColorBrush(Colors.White);
            b3.Content = "3: Weiß auf Grau";
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void b5_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
