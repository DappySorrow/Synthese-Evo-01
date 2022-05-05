using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class AccessDB
    {
        public static DataTable ConnecterBD()
        {
            MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=donneesVentes;UID=root;PASSWORD=;");

            try
            {
                conn.Open();

                string command = "SELECT Province, TypeVeh, Annee, NbUnites, Mntx1000 FROM ventes";

                MySqlCommand cmd = new MySqlCommand(command, conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                DataSet ds = new DataSet(); //using System.Data

                adapter.Fill(ds, "ventes");

                var dt = ds.Tables["ventes"];

                return dt;
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
