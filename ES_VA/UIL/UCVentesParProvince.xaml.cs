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

            //Pour que toutes les lettres soit de la même taille dans le ListBox
            FontFamily courierNew = new FontFamily("Courier New");
            lbProvinceSomme.FontFamily = courierNew;

            Vente.ChargerListeVentes();
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
                List<double> provincesSommes = TotalNbUnitesParProvince(anneeDebut, anneeFin, typeVehicule, provincesNoms);

                AfficherResultats(provincesNoms, provincesSommes);
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
        /// Ramasser les données au lancement de la fenêtre pour permettre une selection
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
            //L'année de début
            int anneeMin = int.Parse(cbAnneesDebut.SelectedItem.ToString());

            //La liste de toute les années, sans doublons
            List<int> annnees = new List<int>();
            foreach (var vente in Vente.ventes)
            {
                annnees.Add((vente as Vente).Annee);
            }
            annnees = annnees.Distinct().ToList();

            //-----------------------------------------------------------------

            //Une liste des années disponnibles
            List<int> newAnnees = new List<int>();
            foreach (var annee in annnees)
            {
                if (annee >= anneeMin)
                {
                    newAnnees.Add(annee);
                }
            }

            //Si la selection est vide
            if (cbAnneesFin.SelectedIndex == -1)
            {
                cbAnneesFin.SelectedItem = newAnnees.ToArray()[0];
            }
            //Si la selection n'est pas vide
            else
            {
                //Si la selection de cbAnneesFin est plus grande que celle de cbAnneesDebut
                if (!(int.Parse(cbAnneesFin.SelectedItem.ToString()) > int.Parse(cbAnneesDebut.SelectedItem.ToString())))
                {
                    cbAnneesFin.SelectedItem = newAnnees.ToArray()[0];
                }
            }

            cbAnneesFin.ItemsSource = newAnnees;
        }

        /// <summary>
        /// Les provinces sous forme de liste de string sans doublons
        /// </summary>
        /// <param name="anneeDebut">L'année de début</param>
        /// <param name="anneeFin">L'année de fin</param>
        /// <param name="typeVehicule">Le type de véhicule</param>
        /// <returns>Une liste de string contenant le noms des provinces, sans doublons</returns>
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

        /// <summary>
        /// Retourne une liste de double représentant le nombre d'unités selon les critères de recherches
        /// </summary>
        /// <param name="anneeDebut">L'année de début</param>
        /// <param name="anneeFin">L'année de fin</param>
        /// <param name="typeVehicule">Le type de véhicule</param>
        /// <param name="provincesNoms">Une liste ayant le noms des provinces</param>
        /// <returns>Une liste de double contenant le total d'unités selon une province</returns>
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

        /// <summary>
        /// Arranger l'espacement du résultats et envoie le résultat sous forme de liste de string directement au ListBox
        /// </summary>
        /// <param name="provincesNoms">La liste des noms de provinces</param>
        /// <param name="provincesSommes">La liste des sommes des provinces</param>
        private void AfficherResultats(List<string> provincesNoms, List<double> provincesSommes)
        {
            const int TAILLE = 43;

            List<string> noms = new List<string>();

            foreach (var nom in provincesNoms)
            {
                int nbEspaces = TAILLE - nom.Length;

                string espaces = "";

                for (int i = 0; i < nbEspaces; i++)
                {
                    espaces += " ";
                }

                string nomFinal = nom + espaces;

                noms.Add(nomFinal);
            }

            List<string> finale = new List<string>();

            for (int i = 0; i < noms.Count; i++)
            {
                string affichage = noms.ToArray()[i] + provincesSommes.ToArray()[i];
                finale.Add(affichage);
            }

            lbProvinceSomme.ItemsSource = finale;
        }
    }
}
