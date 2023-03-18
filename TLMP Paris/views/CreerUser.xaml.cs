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
            if (txt_box_nom.Text == string.Empty || txt_box_password.Text == string.Empty || txt_box_prenom.Text == string.Empty || txt_box_points.Text == string.Empty)
            {
                errors.Add("Une ou plusieurs entrées sont vides :");
                if (txt_box_nom.Text == string.Empty) errors.Add("- Nom");
                if (txt_box_prenom.Text == string.Empty) errors.Add("- Prénom");
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
            User newUser = new(txt_box_prenom.Text, txt_box_nom.Text, 0, txt_box_password.Text, txt_box_userlogin.Text, userTotalPoints, -1, MainWindow.promotions.ToList()[c_box_promotion.SelectedIndex].IdPromotion);
            MainWindow.Users.Add(newUser);
            MessageBox.Show("Utilisateur crée avec succès !", "Utilisateur crée", MessageBoxButton.OK);
        }
    }
}
