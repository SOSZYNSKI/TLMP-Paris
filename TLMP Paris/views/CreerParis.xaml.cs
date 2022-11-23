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

namespace TLMP_Paris
{
    /// <summary>
    /// Logique d'interaction pour CreerParis.xaml
    /// </summary>
    public partial class CreerParis : Page
    {
        public CreerParis()
        {
            InitializeComponent();
        }

        private void btn_validate_pari_Click(object sender, RoutedEventArgs e)
        {
            if (chk_simple.IsChecked == true) ((MainWindow)Application.Current.MainWindow).pageViewer.Content = new views.FormSimple();
            if (chk_special.IsChecked == true) ((MainWindow)Application.Current.MainWindow).pageViewer.Content = new views.FormSpe();
        }
    }
}
