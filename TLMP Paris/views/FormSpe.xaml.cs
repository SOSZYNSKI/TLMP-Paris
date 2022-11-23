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
        List<string> listComboDateMinutes;
        List<string> listComboDateSecondes;
        public FormSpe()
        {
            InitializeComponent();
            listComboDateDay = new List<string>();
            listComboDateMonth = new List<string>();
            listComboDateYear = new List<string>();
            listComboDateMinutes = new List<string>();
            listComboDateSecondes = new List<string>();

            listComboDateYear.AddRange(new string[]
            {
                "2022", "2023"
            });
            combo_years_match.ItemsSource = listComboDateYear;
            combo_years_pari.ItemsSource = listComboDateYear;

            for (int i = 1; i < 12; i++)
            {
                listComboDateMonth.Add(Convert.ToString(i));
            }
            combo_months_match.ItemsSource = listComboDateMonth;
            combo_months_pari.ItemsSource = listComboDateMonth;

            for(int i = 0; i<59 ;i++)
            {
                listComboDateMinutes.Add(Convert.ToString(i));
            }
            combo_minute.ItemsSource = listComboDateMinutes;
            for(int i = 0; i < 60; i++)
            {
                listComboDateSecondes.Add(Convert.ToString(i));
            }
            combo_second.ItemsSource = listComboDateSecondes;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateMatchForm = new DateTime(Convert.ToInt16(combo_years_match.Text), Convert.ToInt16(combo_months_match.Text), Convert.ToInt16(combo_day_match.Text));
            DateTime DateMaxPariForm = new DateTime(Convert.ToInt16(combo_years_pari.Text), Convert.ToInt16(combo_months_pari.Text), Convert.ToInt16(combo_day_pari.Text));
            DateTime DateRangeForm = new DateTime(0, 0, 0, 0, Convert.ToInt16(combo_minute.Text), Convert.ToInt16(combo_second.Text));
            string libelleForm = txt_libelle.Text;
            int recompenseForm = Convert.ToInt16(txt_recompense.Text);
            int pointPenaliteForm = Convert.ToInt16(txt_penalitepoints.Text);
            Pari pari = new Pari(DateMaxPariForm, dateMatchForm, libelleForm, recompenseForm, DateRangeForm, pointPenaliteForm);
            MainWindow.listeParis.Add(pari);
        }

        private void combo_months_match_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Convert.ToInt16(combo_months_match.Text) == 2)
            {
                for (int i = 1; i < 28; i++)
                {
                    listComboDateDay.Add(Convert.ToString(i));
                }
                combo_day_match.ItemsSource = listComboDateDay;
            }
            else if(Convert.ToInt16(combo_months_match.Text)%2 == 0 )
            {
                    for (int i = 1; i < 31; i++)
                    {
                        listComboDateDay.Add(Convert.ToString(i));
                    }
                    combo_day_match.ItemsSource = listComboDateDay;
            }
            else
            {
                for(int i = 1; i<30;i++)
                {
                    listComboDateDay.Add(Convert.ToString(i));
                }
                combo_day_match.ItemsSource = listComboDateDay;
                combo_day_match.ItemsSource = listComboDateDay;
            }
        }
    }
}
