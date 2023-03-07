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

namespace TLMP_Paris.views
{
    /// <summary>
    /// Logique d'interaction pour FormSpe.xaml
    /// </summary>
    public partial class FormSpe : Page
    {
        List<string> listComboDateDay;
        List<string> listComboDateMonth;
        List<string> listComboDateYear;
        List<int> listComboRangePoint;
        public FormSpe()
        {
            InitializeComponent();
            listComboRangePoint = new List<int>();
            listComboDateDay = new List<string>();
            listComboDateMonth = new List<string>();
            listComboDateYear = new List<string>();
            listComboDateYear.AddRange(new string[]
            {
                "2022", "2023"
            });
            combo_years_match.ItemsSource = listComboDateYear;
            combo_years_pari.ItemsSource = listComboDateYear;

            for (int i = 1; i < 13; i++)
            {
                listComboDateMonth.Add(Convert.ToString(i));
            }
            combo_months_match.ItemsSource = listComboDateMonth;
            combo_months_pari.ItemsSource = listComboDateMonth;

            for(int i = 0; i < 100; i++)
            {
                listComboRangePoint.Add(i);
            }
            combo_ecart_point.ItemsSource = listComboRangePoint;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(txt_penalitepoints.Text == string.Empty)
            {
                txt_penalitepoints.Background = Brushes.Red;
                txt_recompense.Background = Brushes.White;
                txt_libelle.Background = Brushes.White;
                txt_libelle_ecart.Background = Brushes.White;
                MessageBox.Show("Erreur, vous n'avez pas remplis les conditions pour créer un pari", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else if(txt_recompense.Text == string.Empty)
            {
                txt_penalitepoints.Background = Brushes.White;
                txt_recompense.Background = Brushes.Red;
                txt_libelle.Background = Brushes.White;
                txt_libelle_ecart.Background = Brushes.White;
                MessageBox.Show("Erreur, vous n'avez pas remplis les conditions pour créer un pari", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else if(txt_libelle.Text == string.Empty)
            {
                txt_penalitepoints.Background = Brushes.White;
                txt_recompense.Background = Brushes.White;
                txt_libelle.Background = Brushes.Red;
                txt_libelle_ecart.Background = Brushes.White;
                MessageBox.Show("Erreur, vous n'avez pas remplis les conditions pour créer un pari", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else if (txt_libelle_ecart.Text == string.Empty)
            {
                txt_penalitepoints.Background = Brushes.White;
                txt_recompense.Background = Brushes.White;
                txt_libelle.Background = Brushes.White;
                txt_libelle_ecart.Background = Brushes.Red;
                MessageBox.Show("Erreur, vous n'avez pas remplis les conditions pour créer un pari", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else if(combo_ecart_point.Text == string.Empty)
            {
                txt_penalitepoints.Background = Brushes.White;
                txt_recompense.Background = Brushes.White;
                txt_libelle.Background = Brushes.White;
                txt_libelle_ecart.Background = Brushes.White;
                MessageBox.Show("Erreur, vous n'avez pas donnée d'écart", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else if(combo_day_match.SelectedItem == null || combo_months_match.SelectedItem == null || combo_years_match.SelectedItem == null)
            {
                txt_penalitepoints.Background = Brushes.White;
                txt_recompense.Background = Brushes.White;
                txt_libelle.Background = Brushes.White;
                txt_libelle_ecart.Background = Brushes.White;
                MessageBox.Show("Erreur, vous n'avez pas précisé correctement la date du match", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else if(combo_day_pari.SelectedItem == null|| combo_months_pari.SelectedItem == null|| combo_years_pari.SelectedItem == null)
            {
                txt_penalitepoints.Background = Brushes.White;
                txt_recompense.Background = Brushes.White;
                txt_libelle.Background = Brushes.White;
                txt_libelle_ecart.Background = Brushes.White;
                MessageBox.Show("Erreur, vous n'avez pas précisé correctement la date de fin pour les paris", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else if(int.TryParse(txt_recompense.Text, out int num) == false)
            {
                txt_recompense.Background = Brushes.Red;
                txt_penalitepoints.Background = Brushes.White;
                txt_libelle.Background = Brushes.White;
                txt_libelle_ecart.Background = Brushes.White;
                MessageBox.Show("Erreur, vous n'avez pas rentré une donnée correcte dans les récompenses, veuillez rentrer un chiffre/nombre", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else if(int.TryParse(txt_penalitepoints.Text, out int num1) == false)
            {
                txt_penalitepoints.Background = Brushes.Red;
                txt_recompense.Background = Brushes.White;
                txt_libelle.Background = Brushes.White;
                txt_libelle_ecart.Background = Brushes.White;
                MessageBox.Show("Erreur, vous n'avez pas rentré une donnée correcte dans les pénalité de points, veuillez rentrer un chiffre/nombre", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else
            {
                DateTime dateMatchForm = new DateTime(Convert.ToInt16(combo_years_match.Text), Convert.ToInt16(combo_months_match.Text), Convert.ToInt16(combo_day_match.Text));
                DateTime DateMaxPariForm = new DateTime(Convert.ToInt16(combo_years_pari.Text), Convert.ToInt16(combo_months_pari.Text), Convert.ToInt16(combo_day_pari.Text));
                int range = Convert.ToInt16(combo_ecart_point.SelectedItem.ToString());
                string libellerange = txt_libelle_ecart.Text;
                string libelleForm = txt_libelle.Text.ToString();
                int recompenseForm = Convert.ToInt16(txt_recompense.Text);
                int pointPenaliteForm = Convert.ToInt16(txt_penalitepoints.Text);
                Pari pari = new Pari(DateMaxPariForm, dateMatchForm, libelleForm, recompenseForm, range, libellerange, pointPenaliteForm);
                MainWindow.listeParis.Add(pari);
                MessageBox.Show("Réussite !, votre paris " + pari.Libelle + " à bien été créée", "Réussite, votre pari à bien été créée", MessageBoxButton.OK);
                txt_penalitepoints.Text = "";
                txt_recompense.Text = "";
                txt_libelle.Text = "";
                txt_libelle_ecart.Text = "";
                combo_day_pari.SelectedItem = 1;
                combo_months_pari.SelectedItem = "1";
                combo_years_pari.SelectedItem = "2022";
                combo_day_match.SelectedItem = 1;
                combo_months_match.SelectedItem = "1";
                combo_years_match.SelectedItem = "2022";
                combo_ecart_point.SelectedItem = 1;
            }
        }

        private void combo_months_match_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listComboDateDay.Clear();
            if ( combo_months_match.SelectedValue.ToString() == "2")
            {
                for (int i = 1; i < 29; i++)
                {
                    listComboDateDay.Add(Convert.ToString(i));
                }
                combo_day_match.ItemsSource = null;
                combo_day_match.ItemsSource = listComboDateDay;
                combo_day_match.Items.Refresh();
            }
            else if (Convert.ToInt16(combo_months_match.SelectedValue.ToString())%2 == 1 )
            {
                    for (int i = 1; i < 32; i++)
                    {
                        listComboDateDay.Add(Convert.ToString(i));
                    }
                    combo_day_match.ItemsSource = null;
                    combo_day_match.ItemsSource = listComboDateDay;
                    combo_day_match.Items.Refresh();
            }
            else
            {
                for(int i = 1; i<31;i++)
                {
                    listComboDateDay.Add(Convert.ToString(i));
                }
                combo_day_match.ItemsSource = null;
                combo_day_match.ItemsSource = listComboDateDay;
                combo_day_match.Items.Refresh();
            }
        }

        private void combo_months_pari_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listComboDateDay.Clear();
            if (combo_months_pari.SelectedValue.ToString() == "2")
            {
                for (int i = 1; i < 29; i++)
                {
                    listComboDateDay.Add(Convert.ToString(i));
                }
                combo_day_pari.ItemsSource = listComboDateDay;
                combo_day_pari.Items.Refresh();

            }
            else if (Convert.ToInt16(combo_months_pari.SelectedValue.ToString())%2 == 1)
            {
                for (int i = 1; i < 32; i++)
                {
                    listComboDateDay.Add(Convert.ToString(i));
                }
                combo_day_pari.ItemsSource = listComboDateDay;
                combo_day_pari.Items.Refresh();
            }
            else
            {
                for (int i = 1; i < 31; i++)
                {
                    listComboDateDay.Add(Convert.ToString(i));
                }
                combo_day_pari.ItemsSource = listComboDateDay;
                combo_day_pari.Items.Refresh();
            }
        }

        private void txt_libelle_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
