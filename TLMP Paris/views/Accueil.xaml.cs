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



            InitializeComponent();
            tbl_topUsers.ItemsSource = MainWindow.Users;
            User u = new User("nom", "unnom", 10, "passeport", "userlogin", 40, 2);
            User u1 = new User("lenom", "deuxnoms", 27, "lespasseports", "lesuserlogin", 90, 99);
            MainWindow.Users.Add(u);
            MainWindow.Users.Add(u1);

            libelle_match_1.Content = "Hello 1";
            libelle_match_2.Content = "Hello 2";
            libelle_match_3.Content = "Hello 3";

            paris_simple_1.Content = "Pari simple 1";
            paris_simple_2.Content = "Pari simple 2";
            paris_simple_3.Content = "Pari simple 3";

            paris_special_1.Content = "Pari special 1";
            paris_special_2.Content = "Pari special 2";
            paris_special_3.Content = "Pari special 3";









    }
    }
}
