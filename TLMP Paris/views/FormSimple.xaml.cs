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
        public FormSimple()
        {
            InitializeComponent();
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
    }
}
