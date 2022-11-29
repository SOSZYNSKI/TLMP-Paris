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

            if(MainWindow.listeParis.Count() >= 3)
            {
                for(int i = 0; i < 3;i++)
                {
                    listpariaccueil.Add(MainWindow.listeParis[i]);
                }
                labelle_date_match_1.Content = listpariaccueil[0].DateMatch;
                labelle_date_pari_1.Content = listpariaccueil[0].DateMax;
                labelle_recompense_1.Content = listpariaccueil[0].PointsEarn;
                libelle_match_1.Content = listpariaccueil[0].Libelle; ;

                if (listpariaccueil[0].Elimination == 1)
                {
                    labelle_spe_1.Content = "Pari simple";
                    labelle_range_1.Visibility = Visibility.Hidden;
                }
                else
                {
                    labelle_spe_1.Content = "Pari Spé";
                    labelle_range_1.Content = " - " + listpariaccueil[0].Penality + " points par " + listpariaccueil[0].Range + " " + listpariaccueil[0].Rangelibelle + " d'écart ";
                }

                labelle_date_match_2.Content = listpariaccueil[1].DateMatch;
                labelle_date_pari_2.Content = listpariaccueil[1].DateMax;
                labelle_recompense_2.Content = listpariaccueil[1].PointsEarn;
                libelle_match_2.Content = listpariaccueil[1].Libelle; ;

                if (listpariaccueil[1].Elimination == 1)
                {
                    labelle_spe_2.Content = "Pari simple";
                    labelle_range_2.Visibility = Visibility.Hidden;
                }
                else
                {
                    labelle_spe_2.Content = "Pari Spé";
                    labelle_range_2.Content = " - " + listpariaccueil[1].Penality + " points par " + listpariaccueil[1].Range + " " + listpariaccueil[1].Rangelibelle + " d'écart ";
                }

                labelle_date_match_3.Content = listpariaccueil[2].DateMatch;
                labelle_date_pari_3.Content = listpariaccueil[2].DateMax;
                labelle_recompense_3.Content = listpariaccueil[2].PointsEarn;
                libelle_match_3.Content = listpariaccueil[2].Libelle; ;

                if (listpariaccueil[2].Elimination == 1)
                {
                    labelle_spe_3.Content = "Pari simple";
                    labelle_range_3.Visibility = Visibility.Hidden;
                }
                else
                {
                    labelle_spe_3.Content = "Pari Spé";
                    labelle_range_3.Content = " - " + listpariaccueil[2].Penality + " points par " + listpariaccueil[2].Range + " " + listpariaccueil[2].Rangelibelle + " d'écart ";
                }
            }
            else if(MainWindow.listeParis.Count() == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    listpariaccueil.Add(MainWindow.listeParis[i]);
                }
                labelle_date_match_1.Content = listpariaccueil[0].DateMatch;
                labelle_date_pari_1.Content = listpariaccueil[0].DateMax;
                labelle_recompense_1.Content = listpariaccueil[0].PointsEarn;
                libelle_match_1.Content = listpariaccueil[0].Libelle; ;

                if (listpariaccueil[0].Elimination == 1)
                {
                    labelle_spe_1.Content = "Pari simple";
                    labelle_range_1.Visibility = Visibility.Hidden;
                }
                else
                {
                    labelle_spe_1.Content = "Pari Spé";
                    labelle_range_1.Content = " - " + listpariaccueil[0].Penality + " points par " + listpariaccueil[0].Range + " " + listpariaccueil[0].Rangelibelle + " d'écart ";
                }

                labelle_date_match_2.Content = listpariaccueil[1].DateMatch;
                labelle_date_pari_2.Content = listpariaccueil[1].DateMax;
                labelle_recompense_2.Content = listpariaccueil[1].PointsEarn;
                libelle_match_2.Content = listpariaccueil[1].Libelle; ;

                if (listpariaccueil[1].Elimination == 1)
                {
                    labelle_spe_2.Content = "Pari simple";
                    labelle_range_2.Visibility = Visibility.Hidden;
                }
                else
                {
                    labelle_spe_2.Content = "Pari Spé";
                    labelle_range_2.Content = " - " + listpariaccueil[1].Penality + " points par " +  listpariaccueil[1].Range + " " + listpariaccueil[1].Rangelibelle + " d'écart ";
                }
            }
            else if(MainWindow.listeParis.Count() == 1)
            {
                listpariaccueil.Add(MainWindow.listeParis[0]);

                labelle_date_match_1.Content = listpariaccueil[0].DateMatch;
                labelle_date_pari_1.Content = listpariaccueil[0].DateMax;
                labelle_recompense_1.Content = listpariaccueil[0].PointsEarn;
                libelle_match_1.Content = listpariaccueil[0].Libelle;

                if (listpariaccueil[0].Elimination == 1)
                {
                    labelle_spe_1.Content = "Pari simple";
                    labelle_range_1.Visibility = Visibility.Hidden;
                }
                else
                {
                    labelle_spe_1.Content = "Pari Spé";
                    labelle_range_1.Content = " - " + listpariaccueil[0].Penality + " points par " + listpariaccueil[0].Range + " "  + listpariaccueil[0].Rangelibelle + " d'écart ";
                }
            }
            else
            {
                libelle_match_1.Content = "Aucun match de prévue pour le moment.";
                libelle_match_2.Content = "Aucun match de prévue pour le moment.";
                libelle_match_3.Content = "Aucun match de prévue pour le moment.";
                labelle_date_pari_1.Visibility = Visibility.Hidden;
                labelle_date_pari_2.Visibility = Visibility.Hidden;
                labelle_date_pari_3.Visibility = Visibility.Hidden;
                labelle_recompense_1.Visibility = Visibility.Hidden;
                labelle_recompense_2.Visibility = Visibility.Hidden;
                labelle_recompense_3.Visibility = Visibility.Hidden;
                labelle_spe_1.Visibility = Visibility.Hidden;
                labelle_spe_2.Visibility = Visibility.Hidden;
                labelle_spe_3.Visibility = Visibility.Hidden;
                labelle_date_match_1.Visibility = Visibility.Hidden;
                labelle_date_match_2.Visibility = Visibility.Hidden;
                labelle_date_match_3.Visibility = Visibility.Hidden;
                labelle_range_1.Visibility = Visibility.Hidden;
                labelle_range_2.Visibility = Visibility.Hidden;
                labelle_range_3.Visibility = Visibility.Hidden;
            }
        }

    }
}
