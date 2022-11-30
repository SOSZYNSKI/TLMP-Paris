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
using TLMP_Paris.Classe;

namespace TLMP_Paris
{
    /// <summary>
    /// Logique d'interaction pour GestionInscription.xaml
    /// </summary>
    public partial class GestionInscription : Page
    {
        readonly List<String> characters = new();

        public GestionInscription()
        {
            InitializeComponent();
            characters.AddRange(new string[] {"aucun", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"});
            cbox_searchby_lastname.ItemsSource = characters;
            cbox_searchby_firstname.ItemsSource = characters;
            cbox_searchby_promotion.ItemsSource = characters;
            tbl_tableau_classement.ItemsSource = MainWindow.Users;
        }

        private void btn_importer_Click(object sender, RoutedEventArgs e)
        {
            MainWindow windowMain = ((MainWindow)Application.Current.MainWindow);
            windowMain.pageHistory.Add(windowMain.pageViewer.Content);
            windowMain.pageViewer.Content = new views.CreerUser();
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            tbl_tableau_classement.ItemsSource = MainWindow.Users.Where(user => {
                bool tmpCheck = false;
                if (txtbox_searchby_lastname.Text.Length > 0) {
                    if (user.SecondName.ToLower() == txtbox_searchby_lastname.Text.ToLower()) tmpCheck = true;
                    else tmpCheck = false;
                } else {
                    if (cbox_searchby_lastname.SelectedIndex > 0 && user.SecondName.ToLower().StartsWith(characters[cbox_searchby_lastname.SelectedIndex])) tmpCheck = true;
                    else if (cbox_searchby_lastname.SelectedIndex > 0 && tmpCheck == true) tmpCheck = false;
                }
                if (txtbox_searchby_firstname.Text.Length > 0) {
                    if (user.UserName.ToLower() == txtbox_searchby_firstname.Text.ToLower()) tmpCheck = true;
                    else tmpCheck = false;
                } else {
                    if (cbox_searchby_firstname.SelectedIndex > 0 && user.UserName.ToLower().StartsWith(characters[cbox_searchby_firstname.SelectedIndex])) tmpCheck = true;
                    else if (cbox_searchby_firstname.SelectedIndex > 0 && tmpCheck == true) tmpCheck = false;
                }
                if (txtbox_searchby_promotion.Text.Length > 0) {
                    if (user.Promotion.PromotionName.ToLower() == txtbox_searchby_promotion.Text.ToLower()) tmpCheck = true;
                    else tmpCheck = false;
                } else {
                    if (cbox_searchby_promotion.SelectedIndex > 0 && user.Promotion.PromotionName.ToLower().StartsWith(characters[cbox_searchby_promotion.SelectedIndex])) tmpCheck = true;
                    else if (cbox_searchby_promotion.SelectedIndex > 0 && tmpCheck == true) tmpCheck = false;
                }
                if (txtbox_searchby_lastname.Text.Length < 1 && txtbox_searchby_firstname.Text.Length < 1 && txtbox_searchby_promotion.Text.Length < 1 && cbox_searchby_firstname.SelectedIndex < 1 && cbox_searchby_lastname.SelectedIndex < 1 && cbox_searchby_promotion.SelectedIndex < 1) return true;
                return tmpCheck;
            }).ToList();
        }
    }
}
