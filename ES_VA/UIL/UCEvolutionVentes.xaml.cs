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

using LiveCharts;
using LiveCharts.Wpf;
using BLL;
using System.Collections.ObjectModel;

namespace UIL
{
    /// <summary>
    /// Logique d'interaction pour UCEvolutionVentes.xaml
    /// </summary>
    public partial class UCEvolutionVentes : UserControl
    {
        public SeriesCollection SC { get; set; }
        public string[] Annees { get; set; }


        public UCEvolutionVentes()
        {
            InitializeComponent();
            Vente.ChargerListeVentes();

            //=======================================================

            List<int> lstDates = Vente.ChargerListeDatesUniques();
            List<string> lstAnnees = new List<string>();

            foreach (var date in lstDates)
            {
                lstAnnees.Add(date.ToString());
            }

            Annees = lstAnnees.ToArray();

            //=======================================================

            List<string> provinces = Vente.ChargerListeProvincesUniques();
            cbProvinces.ItemsSource = provinces;

            List<string> typesVehicule = Vente.ChargerListeVehiculesUniques();
            cbVehicules.ItemsSource = typesVehicule;


        }

        /// <summary>
        /// Quand les ComboBox changent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbProvinces.SelectedIndex != -1 && cbVehicules.SelectedIndex != -1)
            {
                string province = cbProvinces.SelectedItem.ToString();
                string typeVehicule = cbVehicules.SelectedItem.ToString();

                //Liste de la somme moyenne selon l'année et le type de véhicule
                List<double> lstSommeMoyenne = new List<double>();

                double prixMoyen = 0;
                foreach (var vente in Vente.ventes)
                {
                    ObservableCollection<Vente> ventes = new ObservableCollection<Vente>(from item in Vente.ventes
                                                                                         orderby item.Annee
                                                                                         where item.Province == province
                                                                                         where item.TypeVeh == typeVehicule
                                                                                         select item);


                    foreach (var annee in ventes)
                    {
                        prixMoyen += vente.PrixMoyen;
                    }

                    lstSommeMoyenne.Add(prixMoyen);
                    prixMoyen = 0;

                }


                //================================================================================================


                SC = new SeriesCollection()
                {
                    new ColumnSeries
                    {
                        Title = "Évolution des ventes",
                    }
                };
                foreach (var somme in lstSommeMoyenne)
                {
                    //SC[0].Values.Add(somme);

                }

                DataContext = this;
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Title = "Évolution des ventes";
        }
    }
}
