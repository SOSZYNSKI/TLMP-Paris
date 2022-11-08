using MahApps.Metro.Actions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLMP_Paris.Classe;

namespace TLMP_Paris.classes
{
    public class ADOpromotion
    {
        public static SqlConnection connexion = new SqlConnection("Data Source=sql.reseau-labo.fr;User ID=admin_ltmp_db;Password=ltmp_admin_553;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public static void Close()
        {
            connexion.Close();
        }

        public static void Open()
        {
            connexion.Open();
        }

        public List<Promotion> getall()
        {
            List<Promotion> list = new List<Promotion>();

            try
            {
                using (SqlDataAdapter all = new SqlDataAdapter("SELECT * FROM promotions", connexion))
                {
                    DataTable dtTest = new();
                    DataSet dsTest = new();
                    all.Fill(dtTest);
                    all.Fill(dsTest);
                    var firstColumn = dsTest.Tables[0].Rows;
                    foreach(DataRow row in firstColumn)
                    {
                        string promoName = row["nomPromotion"].ToString();
                        int promoID = Convert.ToInt32(row["idPromotion"].ToString());
                        list.Add(new Promotion(promoName, promoID));
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return list;
        }


    }


}
