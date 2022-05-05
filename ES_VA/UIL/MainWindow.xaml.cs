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

using System.Collections.ObjectModel;
using System.Data;
using DAL;


namespace UIL
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public UserControl Ecran { get; set; }

        public UCAccueil Accueil = new UCAccueil();
        
        public UCListerLesVentes ListerLesVentes = new UCListerLesVentes();
        public UCVentesParProvince VentesParProvince = new UCVentesParProvince();
        public UCEvolutionVentes EvolutionVentes = new UCEvolutionVentes();

        public MainWindow()
        {
            InitializeComponent();

            DataTable dt = AccessDB.ConnecterBD();

            Ecran = Accueil;
            Grid.SetRow(Ecran, 0);
            Grid.SetColumn(Ecran, 0);
            userGrid.Children.Add(Ecran);
        }

        private void btnVentes_Click(object sender, RoutedEventArgs e)
        {
            changerEcran(ListerLesVentes);
        }

        private void btnProvince_Click(object sender, RoutedEventArgs e)
        {
            changerEcran(VentesParProvince);
        }

        private void btnEvolution_Click(object sender, RoutedEventArgs e)
        {
            changerEcran(EvolutionVentes);
        }

        private void btnSortie_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void changerEcran(UserControl userControl)
        {
            userGrid.Children.Remove(Ecran);

            Ecran = userControl;
            Grid.SetRow(Ecran, 0);
            Grid.SetColumn(Ecran, 0);
            userGrid.Children.Add(Ecran);
        }
    }
}
