using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLMP_Paris.Classe;
using System.Windows;

namespace TLMP_Paris.classes
{
    public class ADOmethods
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

        public static void deleteall()
        {
            try
            {
                connexion.Open();
                string delparie = "DELETE FROM parie";
                string delu = "DELETE FROM users";
                string delpromo = "DELETE FROM promotions";
                string delparimatch = "DELETE FROM parimatch";
                SqlCommand sqldelusers = new SqlCommand(delu, connexion);
                SqlCommand sqldelparie = new SqlCommand(delparie, connexion);
                SqlCommand sqldelpromo = new SqlCommand(delpromo, connexion);
                SqlCommand sqldelparimatch = new SqlCommand(delparimatch, connexion);
                sqldelparie.ExecuteNonQuery();
                sqldelusers.ExecuteNonQuery();
                sqldelpromo.ExecuteNonQuery();
                sqldelparimatch.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur c'est produite" + ex, "Erreur SQL", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connexion.Close();
            }
        }

        public static void saveall(List<User> lalisteuser, List<Promotion> lalistepromo, List<Pari> listpromo)
        {
            try
            {
                connexion.Open();

                foreach (User u in lalisteuser)
                {
                    string saveu = $"INSERT INTO users (prenomUsers, nomUsers, mdpUsers, loginUsers, totalpointUsers) VALUES ({u.UserName},{u.SecondName},{u.UserPassword}, {u.UserLogin}, {u.TotalPoint});";
                    SqlCommand savinguser = new SqlCommand(saveu, connexion);
                    savinguser.ExecuteNonQuery();
                }

                foreach (Promotion pro in lalistepromo)
                {
                    string savep = $"INSERT INTO promotions (nomPromotion, nombrepersonnesPromotion) VALUES ('{pro.PromotionName}',{pro.NombreTotal});";
                    SqlCommand savingpromo = new SqlCommand(savep, connexion);
                    savingpromo.ExecuteNonQuery();
                }

                foreach (Pari pa in listpromo)
                {
                    string savepa = $"INSERT INTO parimatch (datemaxpariMatch, datepariMatch, resultatMatch, recompensepariMatch, libelleMatch, typePari, eliminatoireMatch, ecartMatch, libelleecartMatch, penaliteMatch) VALUES ({pa.DateMax},{pa.DateMatch},{pa.ResultMatch},{pa.PointsEarn},{pa.Libelle},);";
                    SqlCommand savingparimatch = new SqlCommand(savepa, connexion);
                    connexion.Open();
                    savingparimatch.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur c'est produite" + ex, "Erreur SQL", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connexion.Close();
            }
        }
    }    
}
