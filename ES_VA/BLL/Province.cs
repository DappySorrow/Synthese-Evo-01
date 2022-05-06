using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Province
    {
        public Province(string nom, double nbunites)
        {
            _nom = nom;
            _nbunites = nbunites;
        }

        private string _nom;
        private double _nbunites;

        public string Nom { get { return _nom; } }
        public double NbUnites { get { return _nbunites; } }
    }


}

