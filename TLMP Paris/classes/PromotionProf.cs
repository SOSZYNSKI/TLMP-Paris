using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLMP_Paris.Classe;

namespace TLMP_Paris.classes
{
    public class PromotionProf
    {
        int idpromotion;
        string promotionName;
        int nombreTotal;
        List<User> listUser;
        public int IdPromotion { get => idpromotion; set => idpromotion = value; }
        public List<User> ListUser { get => listUser; set => listUser = value; }
        public string PromotionName { get => promotionName; set => promotionName = value; }
        public int NombreTotal { get => nombreTotal; set => nombreTotal = value; }

        public PromotionProf(string promotionname, int nombreTotal, int idPRomotion)
        {
            PromotionName = promotionname;
            NombreTotal = nombreTotal;
            ListUser = new List<User>();
            this.idpromotion = idPRomotion;
        }
        public void AddUser(User u)
        {
            this.listUser.Add(u);
            NombreTotal = ListUser.Count();
        }
    }
}
