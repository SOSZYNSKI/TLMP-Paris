﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using MahApps.Metro.Controls;
using TLMP_Paris.Classe;
using TLMP_Paris.classes;

namespace TLMP_Paris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public List<object> pageHistory = new();

        public static List<Promotion> promotions = new();
        public static ADOpromotion adopromotions = new();

        public static List<PromotionProf> promotionsProf = new();
        public static ADOpromotionsprofesseurs adopromotionsprof = new();

        public static List<User> Users = new();
        public static ADOuser ADOuser = new();

        public static List<Pari> listeParis = new();
        public static ADOparimatch listeparisADO = new();

        private void OnClosing(object sender, CancelEventArgs e)
        {
            var result = MessageBox.Show("Voulez-vous vraiment quitter ? Vos données seront automatiquement enregistrées", "Vous êtes en train de quitter l'application", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ADOmethods.deleteall();
                ADOmethods.saveall( promotions, promotionsProf, Users, listeParis);
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            loading.Visibility = Visibility.Hidden;
            promotions = adopromotions.getall();
            Users = ADOuser.getall();
            listeParis = listeparisADO.getall();
            pageViewer.Content = new Accueil();
        }

        private void returnButton(object sender, RoutedEventArgs e)
        {
            if (pageHistory.Count < 1) return;
            object lastHistoryItem = pageHistory[^1];
            pageViewer.Content = lastHistoryItem;
            pageHistory.Remove(lastHistoryItem);
        }
        private void refresh(object sender, RoutedEventArgs e)
        {
            pageViewer.Refresh();
        }

        private void btn_accueil_Click(object sender, RoutedEventArgs e)
        {
            loading.Visibility = Visibility.Visible;
            pageHistory.Add(pageViewer.Content);
            pageViewer.Content = new Accueil();
            loadingDelay(200);
        }

        private void btn_gestion_inscription_Click(object sender, RoutedEventArgs e)
        {
            loading.Visibility = Visibility.Visible;
            pageHistory.Add(pageViewer.Content);
            pageViewer.Content = new GestionInscription();
            loadingDelay(200);
        }

        private void btn_creer_paris_Click(object sender, RoutedEventArgs e)
        {
            loading.Visibility = Visibility.Visible;
            pageHistory.Add(pageViewer.Content);
            pageViewer.Content = new CreerParis();
            loadingDelay(200);
        }

        private void btn_gestion_promotion_Click(object sender, RoutedEventArgs e)
        {
            loading.Visibility = Visibility.Visible;
            pageHistory.Add(pageViewer.Content);
            pageViewer.Content = new GestionPromotion();
            loadingDelay(200);
        }

        async private void loadingDelay(int time)
        {
            ldg_progressbar.Value = 0;
            await Task.Delay(time);
            ldg_progressbar.Value = 100;
            await Task.Delay(100);
            loading.Visibility = Visibility.Hidden;
        }

    }
}
