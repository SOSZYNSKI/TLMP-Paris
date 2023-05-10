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
    public class ADOuser
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

        public List<User> getall()
        {
            List<User> listuser = new List<User>();

            try
            {
                using (SqlDataAdapter all = new SqlDataAdapter("SELECT * FROM users", connexion))
                {
                    DataTable dtTest = new();
                    DataSet dsTest = new();
                    all.Fill(dtTest);
                    all.Fill(dsTest);
                    var firstColumn = dsTest.Tables[0].Rows;
                    foreach (DataRow row in firstColumn)
                    {
                        string username = row["prenomUsers"].ToString();
                        string secondname = row["nomUsers"].ToString();
                        int numberwinpari = Convert.ToInt32(row["totalpointgagneUsers"].ToString());
                        string userpassword = row["mdpUsers"].ToString();
                        string userlogin = row["loginUsers"].ToString();
                        int totalpoint = Convert.ToInt32(row["totalpointUsers"].ToString());
                        int iduser = Convert.ToInt32(row["idUsers"].ToString());
                        int idpromotion = Convert.ToInt32(row["FK_users_promotions"].ToString());
                        foreach(Promotion promo in MainWindow.promotions)
                        {
                            if(promo.IdPromotion == idpromotion)
                            {
                                listuser.Add(new User(username, secondname, numberwinpari, userpassword, userlogin, totalpoint, iduser, promo));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Une erreur c'est produite" + e, "Erreur SQL", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return listuser;
        }

        public void save(List<User> listedesuser)
        {
            string del = "DELETE FROM users";

            SqlCommand delete = new SqlCommand(del, connexion);

            try
            {
                connexion.Open();
                delete.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                connexion.Close();
            }

            foreach (User u in listedesuser)
            {
                try
                {
                    string save = $"INSERT INTO users (prenomUsers, nomUsers, mdpUsers, loginUsers, totalpointUsers, FK_users_promotions) VALUES ({u.UserName},{u.SecondName},{u.UserPassword}, {u.UserLogin}, {u.TotalPoint}, {u.Promotion.IdPromotion});";
                    SqlCommand saving = new SqlCommand(save, connexion);
                    connexion.Open();
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
