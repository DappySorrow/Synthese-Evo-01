//Jean-Simon Barbeau --- 1446326
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace BLL
{

    public class Connexion
    {
        public static ObservableCollection<Connexion> utilisateurs = new ObservableCollection<Connexion>();
        private const string NOM_FICHIER = "connexion.json";

        //=================================================================================================

        /// <summary>
        /// L'instance de connexion
        /// </summary>
        private static Connexion instance;

        /// <summary>
        /// S'assurer que l'instance n'est pas déjà occupé
        /// </summary>
        /// <param name="id"></param>
        /// <param name="passwd"></param>
        /// <returns>L'instance active ou une nouvelle instance</returns>
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

        /// <summary>
        /// Retirer l'instance active
        /// </summary>
        public static void RemoveInstance()
        {
            instance = null;
        }

        //=================================================================================================

        private Connexion(string id, string passwd)
        {
            Id = id;
            Passwd = passwd;
        }

        /// <summary>
        /// Constructeur privé pour la désérialisation
        /// </summary>
        private Connexion()
        {
        }

        public string Id { get; set; }
        public string Passwd { get; set; }

        //=================================================================================================

        /// <summary>
        /// Méthode qui charge le fichier json dans la liste de utilisateurs
        /// </summary>
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
