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
    public class Vehicule
    {
        static public ObservableCollection<Vente> vehicules = new ObservableCollection<Vente>();

        public string typeVehicule { get; set; }
    }
}
