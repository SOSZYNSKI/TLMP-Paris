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
            cbox_searchby_promotion.ItemsSource = MainWindow.promotions;
            cbox_searchby_promotion.DisplayMemberPath = "PromotionName";
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
                if (cbox_searchby_promotion.SelectedIndex > 0 && user.Promotion.IdPromotion == (cbox_searchby_promotion.SelectedItem as Promotion).IdPromotion) tmpCheck = true;
                else if (cbox_searchby_promotion.SelectedIndex > 0 && tmpCheck == true) tmpCheck = false;
                if (txtbox_searchby_lastname.Text.Length < 1 && txtbox_searchby_firstname.Text.Length < 1 && cbox_searchby_firstname.SelectedIndex < 1 && cbox_searchby_lastname.SelectedIndex < 1 && cbox_searchby_promotion.SelectedIndex < 1) return true;
                return tmpCheck;
            }).ToList();
        }

        private void btn_supprimer_user_Click(object sender, RoutedEventArgs e)
        {
            object user = tbl_tableau_classement.SelectedItem;
            User selectedUser = user as User;
            MainWindow.Users.Remove(selectedUser);
            tbl_tableau_classement.Items.Refresh();
            txt_box_userlogin.IsEnabled = false;
            txt_box_userlogin.Text = "";
            txt_box_prenom.IsEnabled = false;
            txt_box_prenom.Text = "";
            txt_box_nom.IsEnabled = false;
            txt_box_nom.Text = "";
            txt_box_points.IsEnabled = false;
            txt_box_points.Text = "";
            btn_modifier_user.IsEnabled = false;
            btn_supprimer_user.IsEnabled = false;
        }

        private void btn_modifier_user_Click(object sender, RoutedEventArgs e)
        {
            if (tbl_tableau_classement.SelectedIndex == null) return;
            object user = tbl_tableau_classement.SelectedItem;
            List<string> errors = new();
            int userTotalPoints;
            Regex usernamePattern = new("^[a-zA-Z0-9]+$");
            Regex stringPattern = new("^[a-zA-Z0-9]{3,60}$");
            if (txt_box_userlogin.Text == string.Empty || usernamePattern.IsMatch(txt_box_userlogin.Text) == false ||
                txt_box_prenom.Text == string.Empty || stringPattern.IsMatch(txt_box_prenom.Text) == false ||
                txt_box_nom.Text == string.Empty || stringPattern.IsMatch(txt_box_nom.Text) == false ||
                txt_box_points.Text == string.Empty || !int.TryParse(txt_box_points.Text, out userTotalPoints))
            {
                errors.Add("Il y a plusieurs erreurs :");
                if (txt_box_userlogin.Text == string.Empty) errors.Add("- Le nom d'utilisateur est vide");
                if (usernamePattern.IsMatch(txt_box_userlogin.Text) == false) errors.Add("- Le nom d'utilisateur n'est pas conforme");
                if (txt_box_prenom.Text == string.Empty) errors.Add("- Le prénom est vide");
                if (stringPattern.IsMatch(txt_box_prenom.Text) == false) errors.Add("- Le prénom n'est pas conforme");
                if (txt_box_nom.Text == string.Empty) errors.Add("- Le nom est vide");
                if (stringPattern.IsMatch(txt_box_nom.Text) == false) errors.Add("- Le nom n'est pas conforme");
                if (txt_box_points.Text == string.Empty) errors.Add("- Le total de points est vide");
                if (!int.TryParse(txt_box_points.Text, out userTotalPoints)) errors.Add("- Le nombre de points doit être un nombre");
                MessageBox.Show(string.Join('\n', errors.ToArray()), "Erreurs", MessageBoxButton.OK);
                return;
            }
            if(userTotalPoints < 0)
            {
                MessageBox.Show(string.Join('\n', "Le nombre de points doit être supérieur ou égal à 0", "Erreur, total de points invalide", MessageBoxButton.OK));
                return;
            }
            User selectedUser = user as User;
            MainWindow.Users.Where(c => c.IdUser == selectedUser.IdUser).ToList().ForEach(userF =>
            {
                userF.UserLogin = txt_box_userlogin.Text;
                userF.UserName = txt_box_prenom.Text;
                userF.SecondName = txt_box_nom.Text;
                userF.TotalPoint = userTotalPoints;
            });
            tbl_tableau_classement.Items.Refresh();
            txt_box_userlogin.IsEnabled = false;
            txt_box_userlogin.Text = "";
            txt_box_prenom.IsEnabled = false;
            txt_box_prenom.Text = "";
            txt_box_nom.IsEnabled = false;
            txt_box_nom.Text = "";
            txt_box_points.IsEnabled = false;
            txt_box_points.Text = "";
            btn_modifier_user.IsEnabled = false;
            btn_supprimer_user.IsEnabled = false;
        }

        private void tbl_tableau_classement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(tbl_tableau_classement.SelectedIndex != null)
            {
                if(tbl_tableau_classement.SelectedItem != null)
                {
                    txt_box_userlogin.IsEnabled = true;
                    txt_box_userlogin.Text = (tbl_tableau_classement.SelectedItem as User).UserLogin;
                    txt_box_prenom.IsEnabled = true;
                    txt_box_prenom.Text = (tbl_tableau_classement.SelectedItem as User).UserName;
                    txt_box_nom.IsEnabled = true;
                    txt_box_nom.Text = (tbl_tableau_classement.SelectedItem as User).SecondName;
                    txt_box_points.IsEnabled = true;
                    txt_box_points.Text = (tbl_tableau_classement.SelectedItem as User).TotalPoint.ToString();
                    btn_modifier_user.IsEnabled = true;
                    btn_supprimer_user.IsEnabled = true;
                }
            } else
            {
                txt_box_userlogin.IsEnabled = false;
                txt_box_userlogin.Text = "";
                txt_box_prenom.IsEnabled = false;
                txt_box_prenom.Text = "";
                txt_box_nom.IsEnabled = false;
                txt_box_nom.Text = "";
                txt_box_points.IsEnabled = false;
                txt_box_points.Text = "";
                btn_modifier_user.IsEnabled = false;
                btn_supprimer_user.IsEnabled = false;
            }
        }

        private void btn_import_Click(object sender, RoutedEventArgs e)
        {
            MainWindow windowMain = ((MainWindow)Application.Current.MainWindow);
            windowMain.pageHistory.Add(windowMain.pageViewer.Content);
            windowMain.pageViewer.Content = new views.ImporterAD();
        }
    }
}
