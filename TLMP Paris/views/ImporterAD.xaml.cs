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
using System.DirectoryServices;
using TLMP_Paris.Classe;

namespace TLMP_Paris.views
{
    /// <summary>
    /// Logique d'interaction pour ImporterAD.xaml
    /// </summary>
    public partial class ImporterAD : Page
    {
        public ImporterAD()
        {
            InitializeComponent();
            c_box_promotion.ItemsSource = MainWindow.promotions;
            c_box_promotion.DisplayMemberPath = "PromotionName";
        }

        private void btn_import_Click(object sender, RoutedEventArgs e)
        {
            List<string> errors = new();
            if (txt_box_lien.Text == string.Empty || txt_box_username.Text == string.Empty || txt_box_password.Text == string.Empty || c_box_promotion.SelectedIndex == null)
            {
                errors.Add("Une ou plusieurs entrées sont vides :");
                if (txt_box_lien.Text == string.Empty) errors.Add("- Lien de l'AD");
                if (txt_box_username.Text == string.Empty) errors.Add("- Nom d'Utilisateur");
                if (txt_box_password.Text == string.Empty) errors.Add("- Mot de passe");
                if (c_box_promotion.SelectedItem == null) errors.Add("- Promotion");
                MessageBox.Show(string.Join('\n', errors.ToArray()), "Erreur, entrées vides", MessageBoxButton.OK);
                return;
            }
            DirectoryEntry Ldap = new DirectoryEntry("LDAP://votre-nom-AD", "Login", "Password");
            if(Ldap == null)
            {
                MessageBox.Show("Impossible de se connecter à l'AD", "Erreur, connexion impossible", MessageBoxButton.OK);
                return;
            }
            DirectorySearcher searcher = new DirectorySearcher(Ldap);
            searcher.Filter = "(objectClass=user)";
            int usersAdded = 0;
            try
            {
                foreach (SearchResult result in searcher.FindAll())
                {
                    DirectoryEntry DirEntry = result.GetDirectoryEntry();
                    MainWindow.Users.Add(new User(DirEntry.Properties["givenName"].Value.ToString(), DirEntry.Properties["sn"].Value.ToString(), 0, DirEntry.Properties["userPassword"].Value.ToString(), DirEntry.Properties["SAMAccountName"].Value.ToString(), 0, -1, (c_box_promotion.SelectedItem as Promotion)));
                    usersAdded++;
                }
                MessageBox.Show($"{usersAdded} users ont étés ajoutés à la promotion {(c_box_promotion.SelectedItem as Promotion).PromotionName}", "AD Importée", MessageBoxButton.OK);
            } catch
            {
                MessageBox.Show("Impossible de se connecter à l'AD", "Erreur, connexion impossible", MessageBoxButton.OK);
                return;
            }
        }
    }
}
