﻿using System;
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
                    foreach (DataRow row in firstColumn)
                    {
                        string promoName = row["nomPromotion"].ToString();
                        int nombrepersonnesP = Convert.ToInt32(row["nombrepersonnesPromotion"].ToString());
                        int idpromotion = Convert.ToInt32(row["idPromotion"].ToString());
                        list.Add(new Promotion(promoName, nombrepersonnesP, idpromotion));
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return list;
        }

        public void save(List<Promotion> listepromotion)
        {
            try
            {
                connexion.Open();

                string delu = "DELETE FROM users";
                string delp = "DELETE FROM promotions";
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

            foreach (Promotion p in listepromotion)
            {
                try
                {
                    connexion.Open();
                    string save = $"INSERT INTO dbo.promotions (nomPromotion, nombrepersonnesPromotion) VALUES ({p.PromotionName},{p.NombreTotal});";
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

