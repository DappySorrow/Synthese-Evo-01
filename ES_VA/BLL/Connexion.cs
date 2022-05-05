using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class Connexion
    {
        // variable static de type Auto
        private static Connexion instance;

        //Méthode publique et statique

        public static Connexion GetInstance()
        {
            //Si on n'a pas encore une instance de l'objet Auto, alors on le crée
            if (Connexion.instance == null)
            {
                Connexion.instance = new Connexion();
            }

            //Si l'instance de l'objet existe déjà, on va juste la renvoyer
            return instance;
        }

        //Constructeur privé
        private Connexion()
        {

        }
    }
}
