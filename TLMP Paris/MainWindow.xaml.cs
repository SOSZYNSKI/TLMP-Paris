using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using TLMP_Paris.Classe;
using TLMP_Paris.classes;

namespace TLMP_Paris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public static List<Promotion> promotions = new List<Promotion>();
        public ADOpromotion adopromotions = new();

        public static List<User> Users = new List<User>();
        public ADOuser ADOuser = new();

        public static List<Pari> listeParis = new();
        public ADOparimatch listeparisADO = new ADOparimatch();

        public static List<PariSpe> listeparispe = new();
        public MainWindow()
        {
            InitializeComponent();
            pageViewer.Content = new Accueil();
            loading.Visibility = Visibility.Hidden;
            promotions = adopromotions.getall();
            listeParis = listeparisADO.getall();
            Users = ADOuser.getall();
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
