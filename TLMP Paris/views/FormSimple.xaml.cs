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
    /// Logique d'interaction pour FormSimple.xaml
    /// </summary>
    public partial class FormSimple : Page
    {
        List<int> listComboMonthPari;
        List<int> listComboYear;
        List<int> listNombreJour;
        List<int> listNombrejourPari;

        public FormSimple()
        {
            InitializeComponent();
            listNombrejourPari = new();
            listComboMonthPari = new();
            listNombreJour = new();
            listComboYear = new();
            listComboYear.Add(2022);
            listComboYear.Add(2023);

            combo_years.ItemsSource = listComboYear;
            combo_years_pari.ItemsSource = listComboYear;

            for (int i = 0; i <= 12; i++)
            {
                listComboMonthPari.Add(i);
            }
            combo_months_match1.ItemsSource = listComboMonthPari;
            combo_months_pari.ItemsSource = listComboMonthPari;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(txt_earn.Text == string.Empty)
            {
                txt_equipe_home.Background = Brushes.White;
                txt_equipe_coming.Background = Brushes.White;
                txt_earn.Background = Brushes.Red;
                MessageBox.Show("Erreur, vous n'avez pas remplis les condiitions pour créer un pari", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else if(txt_equipe_coming.Text == string.Empty)
            {
                txt_equipe_home.Background = Brushes.White;
                txt_earn.Background = Brushes.White;
                txt_equipe_coming.Background = Brushes.Red;
                MessageBox.Show("Erreur, vous n'avez pas remplis les condiitions pour créer un pari", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else if(txt_equipe_home.Text == string.Empty)
            {
                txt_earn.Background = Brushes.White;
                txt_equipe_coming.Background = Brushes.White;
                txt_equipe_home.Background = Brushes.Red;
                MessageBox.Show("Erreur, vous n'avez pas remplis les condiitions pour créer un pari", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else if(combo_day_pari.SelectedItem == null)
            {
                MessageBox.Show("Erreur, Veuillez saisir le jours pour la période de fin de pari", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else if(combo_months_pari.SelectedItem == null)
            {
                MessageBox.Show("Erreur, Veuillez saisir le mois pour la période de fin de pari", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else if(combo_years_pari.SelectedItem == null)
            {
                MessageBox.Show("Erreur, Veuillez saisir l'année pour la période de fin de pari", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else if(combo_day_match1.SelectedItem == null)
            {
                MessageBox.Show("Erreur, Veuillez saisir un le jours du match", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else if(combo_months_match1.SelectedItem == null)
            {
                MessageBox.Show("Erreur, Veuillez saisir le mois du match", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else if(combo_years.SelectedItem == null)
            {
                MessageBox.Show("Erreur, Veuillez saisir une l'année du match", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else if (check_no.IsChecked == false && check_yes.IsChecked == false)
            {
                MessageBox.Show("Erreur, Veuillez choisir entre oui ou non", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else if(int.TryParse(txt_earn.Text, out int num) == false)
            {
                txt_earn.Background = Brushes.Red;
                MessageBox.Show("Erreur, Veuillez entrer un chiffre/nombre dans la case des récompenses", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else if(Convert.ToInt16(combo_years_pari.SelectedItem.ToString()) > Convert.ToInt16(combo_years.SelectedItem.ToString()))
            {
                MessageBox.Show("Erreur, l'année de fin de paris ne peut être supérieure à celle de l'année du début du match ", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else if(Convert.ToInt16(combo_months_pari.SelectedItem.ToString()) > Convert.ToInt16(combo_months_match1.SelectedItem.ToString()))
            {
                MessageBox.Show("Erreur, le mois de fin de paris ne peut être supérieure à celle de le mois du début du match ", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else if(Convert.ToInt16(combo_years.SelectedItem.ToString()) > Convert.ToInt16(combo_years_pari.SelectedItem.ToString()) && Convert.ToInt16(combo_months_pari.SelectedItem.ToString()) > Convert.ToInt16(combo_months_match1.SelectedItem.ToString()))
            {
                MessageBox.Show("Erreur, le mois de fin de paris ne peut être supérieure à celle de le mois du début du match ", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else if(Convert.ToInt16(combo_years.SelectedItem.ToString()) > Convert.ToInt16(combo_years_pari.SelectedItem.ToString()) && Convert.ToInt16(combo_months_match1.SelectedItem.ToString()) > Convert.ToInt16(combo_months_pari.SelectedItem.ToString()) && Convert.ToInt16(combo_day_match1.SelectedItem.ToString()) < Convert.ToUInt16(combo_day_pari.SelectedItem.ToString()))
            {
                MessageBox.Show("Erreur, le jours de fin de paris ne peut être supérieure à celle du début du match ", "Erreur, manque quelque chose", MessageBoxButton.OK);
            }
            else
            {

                DateTime DateMatchForm = new DateTime(Convert.ToInt16(combo_years.Text), Convert.ToInt16(combo_months_match1.Text), Convert.ToInt16(combo_day_match1.Text));
                DateTime datePariMaxForm = new DateTime(Convert.ToInt16(combo_years_pari.Text), Convert.ToInt16(combo_months_pari.Text), Convert.ToInt16(combo_day_pari.Text));
                string libelleForm = txt_equipe_home.Text + " vs " + txt_equipe_coming.Text;
                int eliminationForm = 0;
                if (check_yes.IsChecked == true)
                {
                    eliminationForm = 1;
                }
                else if (check_no.IsChecked == true)
                {
                    eliminationForm = 0;

                }
                Pari pari = new Pari(datePariMaxForm, DateMatchForm, libelleForm, Convert.ToInt16(txt_earn.Text), eliminationForm);
                MainWindow.listeParis.Add(pari);
                MessageBox.Show("Sucess!, le paris " + pari.Libelle + "a bien été crée", " Succes, pari crée", MessageBoxButton.OK);
                combo_day_match1.SelectedItem = 1;
                combo_months_match1.SelectedItem = 1;
                combo_years.SelectedItem = 1;
                combo_day_pari.SelectedItem = 1;
                combo_months_pari.SelectedItem = 1;
                combo_years_pari.SelectedItem = 1;
                txt_earn.Text = string.Empty;
                txt_equipe_coming.Text = string.Empty;
                txt_equipe_home.Text = string.Empty;

            }
        }

        private void combo_months_match1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listNombreJour.Clear();
            if (Convert.ToInt16(combo_months_match1.SelectedItem.ToString()) == 2)
            {
                for (int i = 0; i <= 28; i++)
                {
                    listNombreJour.Add(i);
                }
                combo_day_match1.ItemsSource = listNombreJour;
                combo_day_match1.Items.Refresh();
            }
            else if(Convert.ToInt16(combo_months_match1.SelectedItem.ToString())%2 == 1)
            {
                for(int i = 0; i <= 31; i++)
                {
                    listNombreJour.Add(i);
                }
                combo_day_match1.ItemsSource = listNombreJour;
                combo_day_match1.Items.Refresh();
            }
            else
            {
                for(int i = 0; i <= 30; i++)
                {
                    listNombreJour.Add(i);
                }
                combo_day_match1.ItemsSource = listNombreJour;
                combo_day_match1.Items.Refresh();
            }
        }

        private void combo_months_pari_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listNombrejourPari.Clear();
            if(Convert.ToInt16(combo_months_pari.SelectedItem.ToString()) == 2)
            {
                for(int i = 0; i <= 28; i ++)
                {
                    listNombrejourPari.Add(i);
                }
                combo_day_pari.ItemsSource = listNombrejourPari;
                combo_day_pari.Items.Refresh();
            }
            else if(Convert.ToInt16(combo_months_pari.SelectedItem.ToString())%2 == 1)
            {
                for(int i = 0; i <= 31;i++)
                {
                    listNombrejourPari.Add(i);
                }
                combo_day_pari.ItemsSource = listNombrejourPari;
                combo_day_pari.Items.Refresh();
            }
            else
            {
                for(int i  = 0; i <= 30; i++)
                {
                    listNombrejourPari.Add(i);

                }
                combo_day_pari.ItemsSource = listNombrejourPari;
                combo_day_pari.Items.Refresh();
            }
        }
    }
}
