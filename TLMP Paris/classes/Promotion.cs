using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLMP_Paris.Classe
{
    internal class Promotion
    {
        string promotionName;
        int idPromotion;
        internal List<User> ListUser { get => listUser; set => listUser = value; }
        public string PromotionName { get => promotionName; set => promotionName = value; }
        public int IdPromotion { get => idPromotion; set => idPromotion = value; }

        List<User> listUser;

        public Promotion(string promotionname, int idpromotion)
        {
            PromotionName = promotionname;
            IdPromotion = idpromotion;
            ListUser = new List<User>();
        }
        public void AddUser(User u)
        {
            this.listUser.Add(u);
        }
    }
}
