using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel; //Soit capable d'avertir des changements
using System.Collections.ObjectModel;
using DAL;
using System.Data;
using System.Windows;

namespace BLL
{

    public class Vente : INotifyPropertyChanged
    {

        static public ObservableCollection<Vente> ventes = new ObservableCollection<Vente>();

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //==========================================================================================

        private string province;
        public string Province
        {
            get
            {
                return province;
            }
            set
            {
                if (this.province != value)
                {
                    this.province = value;
                    this.NotifyPropertyChanged("Province");
                }
            }
        }


        private string typeVeh;
        public string TypeVeh
        {
            get
            {
                return typeVeh;
            }
            set
            {
                if (this.typeVeh != value)
                {
                    this.typeVeh = value;
                    this.NotifyPropertyChanged("TypeVeh");
                }
            }
        }


        private int annee;
        public int Annee
        {
            get
            {
                return annee;
            }
            set
            {
                if (this.annee != value)
                {
                    this.annee = value;
                    this.NotifyPropertyChanged("Annee");
                }
            }
        }


        private double nbunites;
        public double NbUnites
        {
            get
            {
                return nbunites;
            }
            set
            {
                if (this.nbunites != value)
                {
                    this.nbunites = value;
                    this.NotifyPropertyChanged("NbUnites");
                }
            }
        }


        private double mntx1000;
        public double Mntx1000
        {
            get
            {
                return mntx1000;
            }
            set
            {
                if (this.mntx1000 != value)
                {
                    this.mntx1000 = value;
                    this.NotifyPropertyChanged("Mntx1000");
                }
            }
        }

        //==========================================================================================

        public double PrixMoyen
        {
            get
            {
                return CalculerPrixMoyen();
            }
        }

        //Le prix moyen de vente d’un type de véhicule pour une année et une province donnée
        private double CalculerPrixMoyen()
        {
            return this.mntx1000 / this.NbUnites;
        }

        //==========================================================================================

        public static void ChargerListeVentes()
        {
            DataTable dt = AccessDB.ConnecterBDVentes();

            var ventesList = new ObservableCollection<Vente>();

            if (dt == null)
            {
                MessageBox.Show("Connexion à la BD impossible. Veuillez vérifier votre connexion et redémarrer le programme.", "Connexion à la BD", MessageBoxButton.OK, MessageBoxImage.Warning);
                Environment.Exit(0);
            }


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var vente = new Vente
                {
                    Province = dt.Rows[i]["Province"].ToString(),
                    TypeVeh = dt.Rows[i]["TypeVeh"].ToString(),
                    Annee = int.Parse(dt.Rows[i]["Annee"].ToString()),
                    NbUnites = double.Parse(dt.Rows[i]["NbUnites"].ToString()),
                    Mntx1000 = double.Parse(dt.Rows[i]["Mntx1000"].ToString())
                };

                ventesList.Add(vente);

            }

            ventes = ventesList;
        }

    }
}