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
            pageViewer.Content = new Accueil();
            loading.Visibility = Visibility.Hidden;
        }

        private void btn_accueil_Click(object sender, RoutedEventArgs e)
        {
            loading.Visibility = Visibility.Visible;
            pageViewer.Content = new Accueil();
            loadingDelay(1000);
        }

        private void btn_gestion_inscription_Click(object sender, RoutedEventArgs e)
        {
            loading.Visibility = Visibility.Visible;
            pageViewer.Content = new GestionInscription();
            loadingDelay(1000);
        }

        private void btn_creer_paris_Click(object sender, RoutedEventArgs e)
        {
            loading.Visibility = Visibility.Visible;
            pageViewer.Content = new CreerParis();
            loadingDelay(1000);
        }

        private void btn_gestion_promotion_Click(object sender, RoutedEventArgs e)
        {
            loading.Visibility = Visibility.Visible;
            pageViewer.Content = new GestionPromotion();
            loadingDelay(1000);
        }

        async private void loadingDelay(int time)
        {
            ldg_progressbar.Value = 0;
            await Task.Delay(time);
            ldg_progressbar.Value = 100;
            await Task.Delay(100);
            loading.Visibility = Visibility.Hidden;
        }
    }
}
