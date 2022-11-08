using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLMP_Paris.Classe
{
    public class Promotion
    {
        string promotionName;
        int nombreTotal;
        internal List<User> ListUser { get => listUser; set => listUser = value; }
        public string PromotionName { get => promotionName; set => promotionName = value; }
        public int NombreTotal { get => nombreTotal; set => nombreTotal = value; }

        List<User> listUser;

        public Promotion(string promotionname, int nombreTotal)
        {
            PromotionName = promotionname;
            NombreTotal = nombreTotal;
            ListUser = new List<User>();
        }
        public void AddUser(User u)
        {
            this.listUser.Add(u);
        }
    }
}
