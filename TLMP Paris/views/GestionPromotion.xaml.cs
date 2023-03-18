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
            txt_diminutif.Text = "Diminutif";
            List<User> ListComboUserPromotion = new();

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

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {

            if (txt_Name.Text != null && txt_diminutif.Text != null)
            {
                Promotion newProm = new Promotion(txt_Name.Text,txt_diminutif.Text, 0,Convert.ToInt32(null));
                MainWindow.promotions.Add(newProm);
                dgd_view_tabpromotion.Items.Refresh();
                txt_Name.Text = null;
            }
            else if (txt_Name.Text == null && ComboListUser.SelectedItem != null && txt_diminutif.Text == null)
            {
                object objet = dgd_view_tabpromotion.SelectedItem;
                Promotion promo = objet as Promotion;
                object user = ComboListUser.SelectedItem;
                User userChoose = user as User;
                dgd_view_tabpromotion.Items.Refresh();
                ComboListUser.Items.Refresh();
            }
        }   

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            object objet = dgd_view_tabpromotion.SelectedItem;
            Promotion promo = objet as Promotion;
            int promoID = promo.IdPromotion;
            if(MainWindow.Users.Where(c => c.IdPromotion == promoID || c.Promotion.IdPromotion == promoID).Count() > 0)
            {
                MessageBox.Show("Des utilisateurs sont affectés à cette promotion, merci de leur changer de promotion ou de les supprimés avant la suppression de la promotion", "Erreur, suppression impossible", MessageBoxButton.OK);
                return;
            }
            MainWindow.promotions.Remove(promo);
            MainWindow.Users.ForEach(user =>
            {
                if (user.IdPromotion >= promoID) user.IdPromotion--;
            });
            MainWindow.promotions.ForEach(promotion =>
            {
                if (promotion.IdPromotion >= promoID) promotion.IdPromotion--;
            });
            dgd_view_tabpromotion.Items.Refresh();

        }

        private void btn_modif_Click(object sender, RoutedEventArgs e)
        {
            object promotion = dgd_view_tabpromotion.SelectedItem;
            Promotion promo = promotion as Promotion;
            promo.PromotionName = txt_Name.Text;
            promo.PromotionDiminutif = txt_diminutif.Text;
            dgd_view_tabpromotion.Items.Refresh();
        }

        private void btn_modif_Copy_Click(object sender, RoutedEventArgs e)
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
}
