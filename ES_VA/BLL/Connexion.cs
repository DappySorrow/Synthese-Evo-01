//Jean-Simon Barbeau --- 1446326
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace BLL
{

    public class Connexion
    {
        static public ObservableCollection<Connexion> utilisateurs = new ObservableCollection<Connexion>();
        private const string NOM_FICHIER = "connexion.json";

        //=================================================================================================

        // variable static de type Auto
        private static Connexion instance;

        //Méthode publique et statique
        public static Connexion GetInstance(string id, string passwd)
        {
            //Si on n'a pas encore une instance de l'objet Auto, alors on le crée
            if (instance == null)
            {
                instance = new Connexion(id, passwd);
            }

            //Si l'instance de l'objet existe déjà, on va juste la renvoyer
            return instance;
        }

        public static void RemoveInstance()
        {
            instance = null;
        }

        //=================================================================================================

        //Constructeur privé
        private Connexion(string id, string passwd)
        {
            Id = id;
            Passwd = passwd;
        }

        //Constructeur privé
        private Connexion()
        {
        }

        public string Id { get; set; }
        public string Passwd { get; set; }

        //=================================================================================================

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
