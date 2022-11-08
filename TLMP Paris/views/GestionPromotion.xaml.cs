using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
using TLMP_Paris.Classe;
using TLMP_Paris.classes;

namespace TLMP_Paris
{
    /// <summary>
    /// Logique d'interaction pour GestionPromotion.xaml
    /// </summary>
    public partial class GestionPromotion : Page
    {


        List<Promotion> promotions;

        public GestionPromotion()
        {
 
            InitializeComponent();
            Promotion g = new Promotion("Lenom",2);
            Promotion g1 = new Promotion("Lesnoms",3);
            Promotion g2 = new Promotion("LE",4);
            Promotion g3 = new Promotion("LES",5);
            Promotion g4 = new Promotion("La",9);
            Promotion g5 = new Promotion("lo",11);
            Promotion g6 = new Promotion("vek",40);
            Promotion g7 = new Promotion("zob",17);
            Promotion g8 = new Promotion("element",6);
            Promotion g9 = new Promotion("zola",41);

            promotions = new List<Promotion>();

            promotions.Add(g);
            promotions.Add(g1);
            promotions.Add(g2);
            promotions.Add(g3);
            promotions.Add(g4);
            promotions.Add(g5);
            promotions.Add(g6);
            promotions.Add(g7);
            promotions.Add(g8);
            promotions.Add(g9);

            liste_tabpromotion.ItemsSource = promotions;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_open_test_Click(object sender, RoutedEventArgs e)
        {
            ADO.Open();
        }
    }
}
