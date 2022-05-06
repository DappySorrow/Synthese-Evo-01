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
    /// Logique d'interaction pour UCVentesParProvince.xaml
    /// </summary>
    public partial class UCVentesParProvince : UserControl
    {
        public UCVentesParProvince()
        {
            InitializeComponent();

            Vente.ChargerListeVentes();
            //Vente.ventes;
        }

        /// <summary>
        /// La boutton valider. Classe selon la selection voulue.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            if (cbAnneesDebut.SelectedIndex != -1 && cbAnneesFin.SelectedIndex != -1 && cbTypeVehicule.SelectedIndex != -1)
            {
                int anneeDebut = int.Parse(cbAnneesDebut.SelectedItem.ToString());
                int anneeFin = int.Parse(cbAnneesFin.SelectedItem.ToString());
                string typeVehicule = cbTypeVehicule.SelectedItem.ToString();


                List<string> provincesNoms = NomsDeProvincesSansDoublons(anneeDebut, anneeFin, typeVehicule);
                lbProvince.ItemsSource = provincesNoms;

                //=======================================================================

                List<double> provincesSommes = TotalNbUnitesParProvince(anneeDebut, anneeFin, typeVehicule, provincesNoms);
                lbSomme.ItemsSource = provincesSommes;
            }
            else
            {
                MessageBox.Show("Veillez remplir tous les champs.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);

                foreach (var item in Vente.ventes)
                {
                    Console.WriteLine((item as Vente).Annee);
                }
            }
        }

        /// <summary>
        /// Ramasser les dates au lancement de la fenêtre pour les mettre dans cbAnneesDebut pour permettre une selection de date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

            List<int> annnees = new List<int>();

            foreach (var vente in Vente.ventes)
            {
                annnees.Add((vente as Vente).Annee);
            }

            annnees = annnees.Distinct().ToList();

            cbAnneesDebut.ItemsSource = annnees;

            //================================================================

            List<string> typesVehicule = new List<string>();

            foreach (var vente in Vente.ventes)
            {
                typesVehicule.Add((vente as Vente).TypeVeh);
            }

            typesVehicule = typesVehicule.Distinct().ToList();

            cbTypeVehicule.ItemsSource = typesVehicule;
        }

        /// <summary>
        /// Au changement d'année de début, donne des dates à ComboBox cbAnneesFin pour garder une cohérence de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAnneesDebut_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int anneeMin = int.Parse(cbAnneesDebut.SelectedItem.ToString());

            List<int> annnees = new List<int>();

            foreach (var vente in Vente.ventes)
            {
                annnees.Add((vente as Vente).Annee);
            }
            annnees = annnees.Distinct().ToList();

            List<int> newAnnees = new List<int>();

            foreach (var annee in annnees)
            {
                if (annee > anneeMin)
                {
                    newAnnees.Add(annee);
                }
            }

            cbAnneesFin.ItemsSource = newAnnees;
        }

        private List<string> NomsDeProvincesSansDoublons(int anneeDebut, int anneeFin, string typeVehicule)
        {
            ObservableCollection<Vente> ventes = new ObservableCollection<Vente>(from item in Vente.ventes
                                                                               orderby item.Province
                                                                               where item.Annee >= anneeDebut
                                                                               where item.Annee <= anneeFin
                                                                               where item.TypeVeh == typeVehicule
                                                                               select item);

            List<string> provincesNoms = new List<string>();
            foreach (var vente in ventes)
            {
                provincesNoms.Add(vente.Province);
            }
            return provincesNoms = provincesNoms.Distinct().ToList();
        }

        private List<double> TotalNbUnitesParProvince(int anneeDebut, int anneeFin, string typeVehicule, List<string> provincesNoms)
        {
            List<double> provincesSommes = new List<double>();
            double sommeTotal = 0;
            foreach (var province in provincesNoms)
            {
                ObservableCollection<Vente> ventes = new ObservableCollection<Vente>(from item in Vente.ventes
                                                                                        orderby item.Province
                                                                                        where item.Annee >= anneeDebut
                                                                                        where item.Annee <= anneeFin
                                                                                        where item.Annee <= anneeFin
                                                                                        where item.TypeVeh == typeVehicule
                                                                                        where item.Province == province
                                                                                        select item);


                foreach (var vente in ventes)
                {
                    sommeTotal += vente.NbUnites;
                }

                provincesSommes.Add(sommeTotal);
                sommeTotal = 0;
            }

            return provincesSommes;
        }
    }
}
