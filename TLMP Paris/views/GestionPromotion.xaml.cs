using System;
using System.Collections.Generic;
using System.Data.Common;
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
        public GestionPromotion()
        {

            InitializeComponent();
            dgd_view_tabpromotion.ItemsSource = MainWindow.promotions;
            txt_Name.Text = "Name";
            List<User> ListComboUserPromotion = new();
            User test1 = new User("Login", "Login", 100, "553", "Login", 2,1);
            ListComboUserPromotion.Add(test1);
            foreach (User u in MainWindow.Users)
            {
                if(u.Promotion == null)
                {
                    ListComboUserPromotion.Add(u);
                }
            }
            ComboListUser.ItemsSource = ListComboUserPromotion;
            ComboListUser.Items.Refresh();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {

            if (txt_Name.Text != null)
            {
                Promotion newProm = new Promotion(txt_Name.Text, 0);
                MainWindow.promotions.Add(newProm);
                dgd_view_tabpromotion.Items.Refresh();
                txt_Name.Text = null;
            }
            else if (txt_Name.Text == null && ComboListUser.SelectedItem != null)
            {
                object objet = dgd_view_tabpromotion.SelectedItem;
                Promotion promo = objet as Promotion;
                object user = ComboListUser.SelectedItem;
                User userChoose = user as User;
                promo.AddUser(userChoose);
                dgd_view_tabpromotion.Items.Refresh();
                ComboListUser.Items.Refresh();
            }
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
