using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLMP_Paris.Classe;
using System.Windows;
using System.Diagnostics;

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
                SqlCommand cmdId = new SqlCommand();
                cmdId.CommandText = "resetId";
                cmdId.CommandType = CommandType.StoredProcedure;
                cmdId.Connection = connexion;
                cmdId.ExecuteNonQuery();
               
                foreach (Promotion pro in lalistepromo)
                {
                    string savep = $"INSERT INTO promotions (nomPromotion, nombrepersonnesPromotion) VALUES ('{pro.PromotionName}',{pro.NombreTotal});SELECT @@IDENTITY";
                    SqlCommand savingpromo = new SqlCommand(savep, connexion);
                    Int32 idrecup = Convert.ToInt32(savingpromo.ExecuteScalar());
                    pro.IdPromotion = idrecup;

                }
                connexion.Close();
                foreach (User u in lalisteuser)
                {
                    connexion.Open();
                    string saveu = $"INSERT INTO users (prenomUsers, nomUsers, mdpUsers, loginUsers, totalpointUsers) VALUES ({u.UserName},{u.SecondName},{u.UserPassword}, {u.UserLogin}, {u.TotalPoint});";
                    SqlCommand savinguser = new SqlCommand(saveu, connexion);
                    savinguser.ExecuteNonQuery();
                    connexion.Close();
                }
                foreach (Pari pa in listpromo)
                {
                    connexion.Open();
                    string resetautoincrementpa = "DBCC CHECKIDENT('parimatch', RESEED, 0, 1)";
                    string savepa = $"INSERT INTO parimatch (datemaxpariMatch, datepariMatch, resultatMatch, recompensepariMatch, libelleMatch, typePari, eliminatoireMatch, ecartMatch, libelleecartMatch, penaliteMatch) VALUES ({pa.DateMax},{pa.DateMatch},{pa.ResultMatch},{pa.PointsEarn},{pa.Libelle},);";
                    SqlCommand resetincrementpar = new SqlCommand(resetautoincrementpa, connexion);
                    SqlCommand savingparimatch = new SqlCommand(savepa, connexion);
                    resetincrementpar.ExecuteNonQuery();
                    savingparimatch.ExecuteNonQuery();
                    connexion.Close();
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
