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
using TLMP_Paris.Classe;


namespace TLMP_Paris
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : Page
    {
        public Accueil()
        {

            List<Pari> listpariaccueil = new();

            InitializeComponent();
            tbl_topUsers.ItemsSource = MainWindow.Users;
            tbl_topUsers.Items.Refresh();

            /*for (int i = 0; i<=2; i++)
            {
                listpariaccueil.Add(MainWindow.listeParis[i]);
            }*/

            libelle_match_1.Content = MainWindow.listeParis[0].Libelle;
            /*libelle_match_2.Content = listpariaccueil[1].Libelle;
            libelle_match_3.Content = listpariaccueil[2].Libelle;*/

            paris_simple_1.Content = "Pari simple 1";
            paris_simple_2.Content = "Pari simple 2";
            paris_simple_3.Content = "Pari simple 3";

            paris_special_1.Content = "Pari special 1";
            paris_special_2.Content = "Pari special 2";
            paris_special_3.Content = "Pari special 3";









    }

    }
}
