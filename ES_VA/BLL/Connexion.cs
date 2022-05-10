using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;

namespace BLL
{
    public class Connexion
    {
        static public ObservableCollection<Connexion> utilisateurs = new ObservableCollection<Connexion>();
        private const string NOM_FICHIER = "connexion.json";

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
            //int id, string passwd
            //Id = id;
            //Passwd = passwd;
        }

        public string Id { get; set; }
        public string Passwd { get; set; }


        //Méthode qui charge le fichier json dans la liste de participants
        public static void ChargerFichier()
        {
            StreamReader fichierConnexion;
            string json;

            fichierConnexion = new StreamReader(File.OpenRead(NOM_FICHIER));
            json = fichierConnexion.ReadLine();

            fichierConnexion.Close();

            utilisateurs = JsonConvert.DeserializeObject<ObservableCollection<Connexion>>(json);
        }
    }
}
