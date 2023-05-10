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
using TLMP_Paris.classes;

namespace TLMP_Paris.views
{
    /// <summary>
    /// Logique d'interaction pour CreerUser.xaml
    /// </summary>
    public partial class CreerUser : Page
    {
        public CreerUser()
        {
            InitializeComponent();
            c_box_promotion.ItemsSource = MainWindow.promotions;
            c_box_promotion.DisplayMemberPath = "PromotionName";
        }

        private void btn_creer_Click(object sender, RoutedEventArgs e)
        {
            List<string> errors = new();
            Regex stringPattern = new("^[a-zA-Z0-9]{3,60}$");
            Regex passwordPattern = new("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).{8,30}$");
            Regex usernamePattern = new("^[a-zA-Z0-9]+$");
            if (txt_box_nom.Text == string.Empty || txt_box_password.Text == string.Empty || txt_box_prenom.Text == string.Empty || txt_box_points.Text == string.Empty || txt_box_userlogin.Text == string.Empty)
            {
                errors.Add("Une ou plusieurs entrées sont vides :");
                if (txt_box_nom.Text == string.Empty) errors.Add("- Nom");
                if (txt_box_prenom.Text == string.Empty) errors.Add("- Prénom");
                if (txt_box_userlogin.Text == string.Empty) errors.Add("- Nom d'Utilisateur");
                if (txt_box_password.Text == string.Empty) errors.Add("- Mot de passe");
                if (txt_box_points.Text == string.Empty) errors.Add("- Total de points");
                MessageBox.Show(string.Join('\n', errors.ToArray()), "Erreur, entrées vides", MessageBoxButton.OK);
                return;
            }
            if(c_box_promotion.SelectedIndex == null)
            {
                MessageBox.Show("La promotion n'a pas été choisie", "Erreur, entrées vides", MessageBoxButton.OK);
                return;
            }
            int userTotalPoints;
            if (!int.TryParse(txt_box_points.Text, out userTotalPoints))
            {
                MessageBox.Show("Le total de points n'est pas un nombre", "Erreur, entrée invalide", MessageBoxButton.OK);
                return;
            };
            if(stringPattern.IsMatch(txt_box_nom.Text) == false || stringPattern.IsMatch(txt_box_prenom.Text) == false || passwordPattern.IsMatch(txt_box_password.Text) == false || usernamePattern.IsMatch(txt_box_userlogin.Text) == false || userTotalPoints < 0)
            {
                errors.Add("Une ou plusieurs entrées ne sont pas comformes :");
                if (stringPattern.IsMatch(txt_box_nom.Text) == false) errors.Add("- Nom");
                if (stringPattern.IsMatch(txt_box_prenom.Text) == false) errors.Add("- Prénom");
                if (usernamePattern.IsMatch(txt_box_userlogin.Text) == false) errors.Add("- Nom d'Utilisateur");
                if (passwordPattern.IsMatch(txt_box_password.Text) == false) errors.Add("- Le mot de passe doit avoir une minuscule, une majuscule et un chiffre (minimum 8 caractères)");
                if (userTotalPoints < 0) errors.Add("- Le total de points doit être supérieur ou égal à 0");
                MessageBox.Show(string.Join('\n', errors.ToArray()), "Erreur, entrées non conformes", MessageBoxButton.OK);
                return;
            }
            if(txt_box_confirmpassword.Text != txt_box_password.Text)
            {
                MessageBox.Show("Les mot de passes ne sont pas similaires", "Erreur, mot de passe invalide", MessageBoxButton.OK);
                return;
            };
            User newUser = new(txt_box_prenom.Text, txt_box_nom.Text, 0,txt_box_password.Text, txt_box_userlogin.Text,Convert.ToInt32(txt_box_points.Text), -1, MainWindow.promotions.ToList()[c_box_promotion.SelectedIndex]);
            MainWindow.Users.Add(newUser);
            txt_box_nom.Text = "";
            txt_box_password.Text = ""; 
            txt_box_points.Text = "";
            txt_box_prenom.Text = "";
            txt_box_userlogin.Text = "";
            txt_box_confirmpassword.Text = "";
            c_box_promotion.SelectedIndex = -1;
            MessageBox.Show("Utilisateur crée avec succès !", "Utilisateur crée", MessageBoxButton.OK);
        }

        public string password_hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashBytes);
        }
    }
}
