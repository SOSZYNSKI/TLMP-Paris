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
            listComboMonthPari = new();
            listNombreJour = new();
            listComboYear = new();
            listComboYear.Add(2022);
            listComboYear.Add(2023);

            combo_years.ItemsSource = listComboYear;
            combo_years_pari.ItemsSource = listComboYear;

            for(int i = 0; i <= 12; i ++)
            {
                listComboMonthPari.Add(i);
            }
            combo_months_match1.ItemsSource = listComboMonthPari;
            combo_months_pari.ItemsSource = listComboMonthPari;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime DateMatchForm = new DateTime(Convert.ToInt16(combo_years.Text), Convert.ToInt16(combo_months_match1.Text), Convert.ToInt16(combo_day_match1.Text));
            DateTime datePariMaxForm = new DateTime(Convert.ToInt16(combo_years_pari.Text),Convert.ToInt16(combo_months_pari.Text),Convert.ToInt16(combo_day_pari.Text));
            string libelleForm = txt_equipe_home.Text + " vs " + txt_equipe_coming.Text;
            int eliminationForm = 0;
            if(check_yes.IsChecked == true)
            {
                eliminationForm = 1;
            }
            else if(check_no.IsChecked == true)
            {
                eliminationForm = 0;

            }

            Pari pari = new Pari(datePariMaxForm, DateMatchForm, libelleForm, Convert.ToInt16(txt_earn.Text),eliminationForm);
            MainWindow.listeParis.Add(pari);


        }

        private void combo_months_match1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listNombreJour.Clear();
            if (Convert.ToInt16(combo_months_match1.SelectedItem.ToString()) == 2)
            {
                for (int i = 0; i < 28; i++)
                {
                    listNombreJour.Add(i);
                }
                combo_day_match1.ItemsSource = listNombreJour;
                combo_day_pari.Items.Refresh();
            }
            else if(Convert.ToInt16(combo_months_match1.SelectedItem.ToString())%2 == 1)
            {
                for(int i = 0; i <31; i++)
                {
                    listNombreJour.Add(i);
                }
                combo_day_match1.ItemsSource = listNombreJour;
                combo_day_pari.Items.Refresh();
            }
            else
            {
                for(int i = 0; i < 30; i++)
                {
                    listNombreJour.Add(i);
                }
                combo_day_match1.ItemsSource = listNombreJour;
                combo_day_pari.Items.Refresh();
            }
        }

        private void combo_months_pari_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listNombrejourPari.Clear();
            if(Convert.ToInt16(combo_months_pari.SelectedItem.ToString()) == 2)
            {
                for(int i = 0; i < 28; i ++)
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
