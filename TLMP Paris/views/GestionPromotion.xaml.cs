using System;
using System.Collections.Generic;
using System.Data.Common;
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

namespace TLMP_Paris
{
    /// <summary>
    /// Logique d'interaction pour GestionPromotion.xaml
    /// </summary>
    public partial class GestionPromotion : Page
    {
        List<Promotion> promotions = new();
        public GestionPromotion()
        {
            InitializeComponent();
            ADOpromotion adopromotions = new ADOpromotion();
            promotions = adopromotions.getall();
            dgd_view_tabpromotion.ItemsSource = promotions;
            txt_Name.Text = "Name";
            txt_nombre.Text = "Nombre";
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            Promotion newProm = new Promotion(txt_Name.Text, Convert.ToInt32(txt_nombre.Text));
            MainWindow.promotions.Add(newProm);
            dgd_view_tabpromotion.Items.Refresh();
        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            object objet = dgd_view_tabpromotion.SelectedItem;
            Promotion promo = objet as Promotion;
            MainWindow.promotions.Remove(promo);
            dgd_view_tabpromotion.Items.Refresh();

        }
    }
}
