using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TLMP_Paris.Classe;

namespace TLMP_Paris.classes
{
    public class ADOpromotionsprofesseurs
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

        public List<PromotionProf> getall()
        {
            List<PromotionProf> list = new List<PromotionProf>();

            try
            {
                using (SqlDataAdapter all = new SqlDataAdapter("SELECT * FROM promotionsprofesseurs", connexion))
                {
                    DataTable dtTest = new();
                    DataSet dsTest = new();
                    all.Fill(dtTest);
                    all.Fill(dsTest);
                    var firstColumn = dsTest.Tables[0].Rows;
                    foreach (DataRow row in firstColumn)
                    {
                        string promoName = row["nomProfesseurpromotion"].ToString();
                        int nombrepersonnesP = Convert.ToInt32(row["nombrepersonnepromotionProfesseur"].ToString());
                        int idpromotion = Convert.ToInt32(row["idPromotionprofesseur"].ToString());
                        list.Add(new PromotionProf(promoName, nombrepersonnesP, idpromotion));
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return list;
        }

        public void save(List<PromotionProf> listepromotion)
        {
            try
            {
                connexion.Open();

                string delu = "DELETE FROM users";
                string delp = "DELETE FROM promotionsprofesseurs";
                SqlCommand deleteu = new SqlCommand(delu, connexion);
                deleteu.ExecuteNonQuery();
                SqlCommand deletep = new SqlCommand(delp, connexion);
                deletep.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Une erreur c'est produite" + e, "Erreur SQL", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connexion.Close();
            }

            foreach (PromotionProf p in listepromotion)
            {
                try
                {
                    connexion.Open();
                    string save = $"INSERT INTO dbo.promotionsprofesseurs (nomPromotionprofesseur, nombrepersonnepromotionProfesseur) VALUES ({p.PromotionName},{p.NombreTotal});";
                    SqlCommand saving = new SqlCommand(save, connexion);
                    saving.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    connexion.Close();
                }

            }


        }

    }
}

