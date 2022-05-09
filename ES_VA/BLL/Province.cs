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
    public class Province
    {
        static public ObservableCollection<Vente> provinces = new ObservableCollection<Vente>();   

        public string nomProvince { get; set; }
        public string capitale { get; set; }
        public int superficie { get; set; }
        public int population { get; set; }
    }
}
