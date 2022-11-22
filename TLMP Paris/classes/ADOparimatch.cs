﻿using System;
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
    public class ADOparimatch
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

        public List<Pari> getall()
        {
            List<PariSpe> listSpe = new List<PariSpe>();
            List<PariSimple> listSimple = new List<PariSimple>();

            try
            {
                using (SqlDataAdapter all = new SqlDataAdapter("SELECT * FROM parimatch", connexion))
                {
                    DataTable dtTest = new();
                    DataSet dsTest = new();
                    all.Fill(dtTest);
                    all.Fill(dsTest);
                    var firstColumn = dsTest.Tables[0].Rows;
                    foreach (DataRow row in firstColumn)
                    {
                        int idpari = Convert.ToInt16(row["idpariMatch"].ToString());
                        DateTime datemaxparimatch = Convert.ToDateTime(row["datemaxpariMatch"].ToString());
                        DateTime dateparimatch = Convert.ToDateTime(row["datepariMatch"].ToString());
                        int recompensematch = Convert.ToInt16(row["recompensepariMatch"].ToString());
                        string libellematch = Convert.ToString(row["libelleMatch"].ToString());
                        string typepari = Convert.ToString(row["typePari"].ToString());
                        int eliminatoirematch = Convert.ToInt16(row["eliminatoireMatch"].ToString());
                        DateTime ecartmatch = Convert.ToDateTime(row["ecartMatch"].ToString());
                        int penalitematch = Convert.ToInt16(row["penaliteMatch"].ToString());

                        if (typepari == "spe")
                        {
                            listSpe.Add(new PariSpe(ecartmatch, penalitematch, datemaxparimatch, dateparimatch, libellematch, recompensematch, idpari));
                        }
                        else
                        {
                            listSimple.Add(new PariSimple(eliminatoirematch, datemaxparimatch, dateparimatch, libellematch, recompensematch, idpari));
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //return listSpe listSimple;
            return null;
        }

        public void save(List<Pari> listepari)
        {
            string del = "DELETE FROM pariMatch";

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

            foreach (Pari p in listepari)
            {
                try
                {
                    string save = $"INSERT INTO parimatch (nomPromotion, nombrepersonnesPromotion) VALUES ({p.},{p.NombreTotal});";
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
