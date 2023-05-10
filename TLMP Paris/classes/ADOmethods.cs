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
using System.Security.Cryptography;

namespace TLMP_Paris.classes
{
    public class ADOmethods
    {
        public static SqlConnection connexion = new SqlConnection("Data Source=sql.reseau-labo.fr;User ID=admin_ltmp_db;Password=ltmp_admin_553;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        public static void deleteall()
        {
            try
            {
                connexion.Open();
                string delpromo = "DELETE FROM promotions";
                string delu = "DELETE FROM users";
                string delparie = "DELETE FROM parie;";
                string delparimatch = "DELETE FROM parimatch";
                SqlCommand sqldelusers = new SqlCommand(delu, connexion);
                SqlCommand sqldelparie = new SqlCommand(delparie, connexion);
                SqlCommand sqldelpromo = new SqlCommand(delpromo, connexion);
                SqlCommand sqldelparimatch = new SqlCommand(delparimatch, connexion);
                sqldelusers.ExecuteNonQuery();
                sqldelpromo.ExecuteNonQuery();
                sqldelparie.ExecuteNonQuery();
                sqldelparimatch.ExecuteNonQuery();
                connexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur c'est produite" + ex, "Erreur SQL", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void saveall(List<Promotion> lalistepromo,List<PromotionProf> listepromoprof, List<User> lalisteuser, List<Pari> listpromo)
        {
            try
            {
                connexion.Open();
                int id = 0;
                SqlCommand cmdId = new SqlCommand();
                cmdId.CommandText = "resetId";
                cmdId.CommandType = CommandType.StoredProcedure;
                cmdId.Connection = connexion;
                cmdId.ExecuteNonQuery();
                string resetautoincrementpa = "DBCC CHECKIDENT('parimatch', RESEED, 0)";
                string restauIncrementPromo = "DBCC CHECKIDENT('promotions',RESEED,0)";
                string restauIncrementPromoProf = "DBCC CHECKIDENT('promotionsprofesseurs',RESEED,0)";
                string restauIncrementUser = "DBCC CHECKIDENT('users',RESEED,0)";

                foreach (Promotion pro in lalistepromo)
                {
                    id = id + 1;
                    string activateIdentityInsertQuery = "SET IDENTITY_INSERT promotions ON";
                    string deactivateIdentityInsertQuery = "SET IDENTITY_INSERT promotions OFF";
                    SqlCommand onid = new SqlCommand(activateIdentityInsertQuery, connexion);
                    SqlCommand offid = new SqlCommand(deactivateIdentityInsertQuery, connexion);
                    string savep = $"INSERT INTO promotions (idPromotion,nomPromotion,diminutifs,nombrepersonnesPromotion) VALUES ({id},'{pro.PromotionName}','{pro.PromotionDiminutif}',{pro.NombreTotal});SELECT @@IDENTITY";
                    SqlCommand savingpromo = new SqlCommand(savep, connexion);
                    SqlCommand resetincrement = new SqlCommand(restauIncrementPromo, connexion);
                    onid.ExecuteNonQuery();
                    resetincrement.ExecuteNonQuery();
                    savingpromo.ExecuteNonQuery();
                    offid.ExecuteNonQuery();
                }
                id = 0;
                foreach (PromotionProf professeur in listepromoprof)
                {
                    id = id + 1;
                    string activateIdentityInsertQuery = "SET IDENTITY_INSERT promotionsprofesseurs ON";
                    string deactivateIdentityInsertQuery = "SET IDENTITY_INSERT promotionsprofesseurs OFF";
                    SqlCommand onid = new SqlCommand(activateIdentityInsertQuery, connexion);
                    SqlCommand offid = new SqlCommand(deactivateIdentityInsertQuery, connexion);
                    string savep = $"INSERT INTO promotionsprofesseurs (idPromotionprofesseur,nomProfesseurpromotion,diminutifsProfesseur,nombrepersonnepromotionProfesseur) VALUES ('{id},{professeur.PromotionName}','{professeur.DiminutifPromProf}',{professeur.NombreTotal});SELECT @@IDENTITY";
                    SqlCommand savingpromo = new SqlCommand(savep, connexion);
                    SqlCommand resetincrement = new SqlCommand(restauIncrementPromoProf, connexion);
                    onid.ExecuteNonQuery();
                    resetincrement.ExecuteNonQuery();
                    savingpromo.ExecuteNonQuery();
                    offid.ExecuteNonQuery();
                }

                id = 0;
                foreach (User u in lalisteuser)
                {
                    id = id + 1;
                    string activateIdentityInsertQuery = "SET IDENTITY_INSERT users ON";
                    string deactivateIdentityInsertQuery = "SET IDENTITY_INSERT users OFF";
                    string getUserPromotionRequest = $"SELECT idPromotion FROM promotions WHERE nomPromotion = '{u.Promotion.PromotionName}';";
                    SqlCommand onid = new SqlCommand(activateIdentityInsertQuery, connexion);
                    SqlCommand offid = new SqlCommand(deactivateIdentityInsertQuery, connexion);
                    SqlCommand userPromotion = new SqlCommand(getUserPromotionRequest, connexion);
                    int iduser = (int)userPromotion.ExecuteScalar();
                    string saveu = $"INSERT INTO users (idUsers,prenomUsers, nomUsers, mdpUsers, loginUsers, totalpointUsers,totalpointgagneUsers,FK_users_promotions) VALUES ({id},'{u.UserName}','{u.SecondName}','{u.UserPassword}', '{u.UserLogin}',{u.NumberWinParis}, {u.TotalPoint}, {iduser});";
                    SqlCommand resetincrement = new SqlCommand(restauIncrementUser, connexion);
                    SqlCommand savinguser = new SqlCommand(saveu, connexion);
                    onid.ExecuteNonQuery();
                    resetincrement.ExecuteNonQuery();
                    savinguser.ExecuteNonQuery();
                    offid.ExecuteNonQuery();
                }
                id = 0;
                foreach (Pari pa in listpromo)
                {
                    id = id + 1;
                    string activateIdentityInsertQuery = "SET IDENTITY_INSERT parimatch ON";
                    string deactivateIdentityInsertQuery = "SET IDENTITY_INSERT parimatch OFF";
                    SqlCommand onid = new SqlCommand(activateIdentityInsertQuery, connexion);
                    SqlCommand offid = new SqlCommand(deactivateIdentityInsertQuery, connexion);
                    string savepa = $"INSERT INTO parimatch (idpariMatch,datemaxpariMatch, datepariMatch, resultatMatch, recompensepariMatch, libelleMatch, eliminatoireMatch, ecartMatch, libelleecartMatch, penaliteMatch) VALUES ({id},{"'" + pa.DateMax + "'"},{"'" + pa.DateMatch + "'"},{Convert.ToInt32(pa.ResultMatch)},{Convert.ToInt32(pa.PointsEarn)},{"'" + Convert.ToString(pa.Libelle) + "'"},{Convert.ToInt32(pa.Elimination)}, {Convert.ToInt32(pa.Range)}, {"'" + Convert.ToString(pa.Rangelibelle) + "'"}, {Convert.ToInt32(pa.Penality)});";
                    SqlCommand resetincrementpar = new SqlCommand(resetautoincrementpa, connexion);
                    SqlCommand savingparimatch = new SqlCommand(savepa, connexion);
                    onid.ExecuteNonQuery();
                    resetincrementpar.ExecuteNonQuery();
                    savingparimatch.ExecuteNonQuery();
                    offid.ExecuteNonQuery();
                }
                connexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur c'est produite" + ex, "Erreur SQL", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }    
}
