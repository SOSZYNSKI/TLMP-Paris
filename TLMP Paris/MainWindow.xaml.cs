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
using MahApps.Metro.Controls;

namespace TLMP_Paris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_accueil_Click(object sender, RoutedEventArgs e)
        {
            pageViewer.Content = new Accueil();
        }

        private void btn_gestion_inscription_Click(object sender, RoutedEventArgs e)
        {
            pageViewer.Content = new GestionInscription();
        }

        private void btn_creer_paris_Click(object sender, RoutedEventArgs e)
        {
            pageViewer.Content = new CreerParis();
        }

        private void btn_gestion_promotion_Click(object sender, RoutedEventArgs e)
        {
            pageViewer.Content = new GestionPromotion();
        }
    }
}
