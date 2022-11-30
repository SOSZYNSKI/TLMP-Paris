using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLMP_Paris.Classe
{
    public class Promotion
    {
        int idpromotion;
        string promotionName;
        int nombreTotal;
        string promotionDiminutif;
        List<User> listUser;

        public string PromotionDiminutif { get => promotionDiminutif; set => promotionDiminutif = value; }
        public int IdPromotion { get => idpromotion; set => idpromotion = value; }
        public List<User> ListUser { get => listUser; set => listUser = value; }
        public string PromotionName { get => promotionName; set => promotionName = value; }
        public int NombreTotal { get => nombreTotal; set => nombreTotal = value; }

        public Promotion(string promotionname, string diminutif,int nombreTotal,int idPRomotion)
        {
            PromotionName = promotionname;
            this.promotionDiminutif = diminutif;
            NombreTotal = nombreTotal;
            ListUser = new List<User>();
            this.idpromotion = idPRomotion;
        }
        public void AddUser(User u)
        {
            this.listUser.Add(u);
            NombreTotal = ListUser.Count;
        }
    }
}
