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

using BLL;
using System.Collections.ObjectModel;

namespace UIL
{
    /// <summary>
    /// Logique d'interaction pour UCListerLesVentes.xaml
    /// </summary>
    public partial class UCListerLesVentes : UserControl
    {
        public UCListerLesVentes()
        {
            InitializeComponent();
            Vente.ChargerListeVentes();
            dgVentes.ItemsSource = Vente.ventes;
        }

        private void cbTrier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //Décroissant des années
            if (cbTrier.SelectedIndex == 0)
            {
                // https://docs.microsoft.com/en-us/windows/communitytoolkit/controls/datagrid_guidance/group_sort_filter
                dgVentes.ItemsSource = new ObservableCollection<Vente>(from item in Vente.ventes orderby item.Annee descending select item);
            }

            //Ordre décroissant des NbUnites
            if (cbTrier.SelectedIndex == 1)
            {
                dgVentes.ItemsSource = new ObservableCollection<Vente>(from item in Vente.ventes orderby item.NbUnites descending select item);
            }

            //Ordre décroissant des prix moyens de vente
            if (cbTrier.SelectedIndex == 2)
            {
                dgVentes.ItemsSource = new ObservableCollection<Vente>(from item in Vente.ventes orderby item.PrixMoyen descending select item);
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Title = "Liste des ventes";
        }
    }
}
