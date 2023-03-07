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
            btn_validate_pari.IsEnabled = false;
            if (MainWindow.listeParis.Count > 0)
            {
                if(MainWindow.listeParis.Count > 1)
                {
                    Classe.Pari avantDernierPari = MainWindow.listeParis[^2];
                    lbl_last_paris_special.Content = $"{avantDernierPari.Libelle}";
                    lbl_score_last_paris_special.Content = $"{avantDernierPari.ResultMatch}";
                }
                Classe.Pari dernierPari = MainWindow.listeParis[^1];
                lbl_last_paris_simple.Content = $"{dernierPari.Libelle}";
                lbl_score_last_paris_simple.Content = $"{dernierPari.ResultMatch}";
            }
        }
        private void btn_validate_pari_Click(object sender, RoutedEventArgs e)
        {
            MainWindow windowMain = ((MainWindow)Application.Current.MainWindow);
            if (chk_simple.IsChecked == true) {
                windowMain.pageHistory.Add(windowMain.pageViewer.Content);
                windowMain.pageViewer.Content = new views.FormSimple();
            }
            if (chk_special.IsChecked == true) {
                windowMain.pageHistory.Add(windowMain.pageViewer.Content);
                windowMain.pageViewer.Content = new views.FormSpe();
            }
        }

        private void chk_special_Checked(object sender, RoutedEventArgs e)
        {
            btn_validate_pari.IsEnabled = true;
        }

        private void chk_simple_Checked(object sender, RoutedEventArgs e)
        {
            btn_validate_pari.IsEnabled = true;
        }
        private void chk_special_Checked(object sender, RoutedEventArgs e)
        {
            btn_validate_pari.IsEnabled = true;
        }

        private void chk_simple_Checked(object sender, RoutedEventArgs e)
        {
            btn_validate_pari.IsEnabled = true;
        }
    }
}
