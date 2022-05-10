﻿using System;
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

using BLL;
using System.Collections.ObjectModel;
using System.Data;


namespace UIL
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public UserControl Ecran { get; set; }
        public UserControl PlaceIcon { get; set; }

        public UCAccueil Accueil = new UCAccueil();

        public UCIcon CandaIcon = new UCIcon();

        public UCListerLesVentes ListerLesVentes = new UCListerLesVentes();
        public UCVentesParProvince VentesParProvince = new UCVentesParProvince();
        public UCEvolutionVentes EvolutionVentes = new UCEvolutionVentes();

        public MainWindow()
        {
            InitializeComponent();

            Ecran = Accueil;
            Grid.SetRow(Ecran, 0);
            Grid.SetColumn(Ecran, 0);
            userGrid.Children.Add(Ecran);

            PlaceIcon = CandaIcon;
            Grid.SetRow(PlaceIcon, 0);
            Grid.SetColumn(PlaceIcon, 0);
            iconGrid.Children.Add(PlaceIcon);
        }

        /// <summary>
        /// Afficher UCListerLesVentes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVentes_Click(object sender, RoutedEventArgs e)
        {
            changerEcran(ListerLesVentes);
        }

        /// <summary>
        /// Afficher VentesParProvince
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProvince_Click(object sender, RoutedEventArgs e)
        {
            changerEcran(VentesParProvince);
        }

        /// <summary>
        /// Afficher EvolutionVentes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEvolution_Click(object sender, RoutedEventArgs e)
        {
            changerEcran(EvolutionVentes);
        }

        /// <summary>
        /// Quitter le programme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSortie_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Êtes-vous sûr de vouloir arrêter le programme?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        /// <summary>
        /// Remplacer le UserControl Ecran par un autre UserControl
        /// </summary>
        /// <param name="userControl">Le UserControl voulu</param>
        private void changerEcran(UserControl userControl)
        {
            userGrid.Children.Remove(Ecran);

            Ecran = userControl;
            Grid.SetRow(Ecran, 0);
            Grid.SetColumn(Ecran, 0);
            userGrid.Children.Add(Ecran);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            SectionMenu.Visibility = Visibility.Hidden;
            Connexion.ChargerFichier();
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            if (tbId.Text != "" && pbPass.Password != "")
            {
                bool validation = false;

                Connexion connexion = Connexion.GetInstance(tbId.Text, pbPass.Password);

                foreach (var utilisateur in Connexion.utilisateurs)
                {
                    if (connexion.Id == utilisateur.Id && connexion.Passwd == utilisateur.Passwd)
                    {
                        validation = true;
                    }
                }

                if (validation)
                {
                    MessageBox.Show("Bonjour " + connexion.Id + ".", "Réussite", MessageBoxButton.OK, MessageBoxImage.Information);
                    SectionMenu.Visibility = Visibility.Visible;
                    SectionConnexion.Visibility = Visibility.Hidden;
                    SectionDeconnection.Visibility = Visibility.Visible;

                    txtId.Text = connexion.Id;
                }
                else
                {
                    MessageBox.Show("Id ou Pass invalide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    Connexion.RemoveInstance();
                }
            }
            else
            {
                MessageBox.Show("Le Id ou Pass ne peuvent être null", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Deconnection_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Voulez-vous vraiment vous déconnecter?", "Deconnection", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                SectionMenu.Visibility = Visibility.Hidden;
                SectionConnexion.Visibility = Visibility.Visible;
                SectionDeconnection.Visibility = Visibility.Hidden;

                tbId.Text = "";
                pbPass.Password = "";

                changerEcran(Accueil);

                ListerLesVentes = new UCListerLesVentes();
                VentesParProvince = new UCVentesParProvince();
                EvolutionVentes = new UCEvolutionVentes();

                Connexion.RemoveInstance();
            }
        }
    }
}
