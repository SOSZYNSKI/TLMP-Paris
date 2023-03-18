using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private void btn_supprimer_user_Click(object sender, RoutedEventArgs e)
        {
            object user = tbl_tableau_classement.SelectedItem;
            User selectedUser = user as User;
            MainWindow.Users.Remove(selectedUser);
            tbl_tableau_classement.Items.Refresh();
        }

        private void btn_modifier_user_Click(object sender, RoutedEventArgs e)
        {
            if (tbl_tableau_classement.SelectedIndex == null) return;
            object user = tbl_tableau_classement.SelectedItem;
            List<string> errors = new();
            Regex passwordPattern = new("^(?=.*[a-z])(?=.*[A-Z]).{8,30}$");
            Regex usernamePattern = new("^[a-zA-Z0-9]+$");
            if (txt_box_userlogin.Text == string.Empty || txt_box_password.Text == string.Empty || passwordPattern.IsMatch(txt_box_password.Text) == false || usernamePattern.IsMatch(txt_box_userlogin.Text) == false)
            {
                errors.Add("Il y a plusieurs erreurs :");
                if (txt_box_userlogin.Text == string.Empty) errors.Add("- Le nom d'utilisateur est vide");
                if (txt_box_password.Text == string.Empty) errors.Add("- Le mot de passe est vide");
                if (usernamePattern.IsMatch(txt_box_userlogin.Text) == false) errors.Add("- Le nom d'utilisateur n'est pas conforme");
                if (passwordPattern.IsMatch(txt_box_password.Text) == false) errors.Add("- Le mot de passe n'est pas conforme");
                MessageBox.Show(string.Join('\n', errors.ToArray()), "Erreurs", MessageBoxButton.OK);
                return;
            }
            User selectedUser = user as User;
            MainWindow.Users.Where(c => c.IdUser == selectedUser.IdUser).ToList().ForEach(userF =>
            {
                userF.UserLogin = txt_box_userlogin.Text;
                userF.UserPassword = txt_box_password.Text;
            })
        }
    }
}
