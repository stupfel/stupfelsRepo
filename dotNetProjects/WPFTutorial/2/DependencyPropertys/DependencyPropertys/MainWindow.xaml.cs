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

namespace DependencyPropertys
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

        private void abrufen(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(tb.Text);
            MessageBox.Show(tb.GetValue(TextBox.TextProperty) + "");
        }

        private void setzen(object sender, RoutedEventArgs e)
        {
            tb.Text = "Guten Tag";
            tb.SetValue(TextBox.TextProperty, "Guten Tag 2 ");
        }
    }
}
