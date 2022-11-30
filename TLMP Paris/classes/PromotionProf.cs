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
        List<User> listUserpromotionprof;
        string diminutifPromProf;

        public string DiminutifPromProf { get => diminutifPromProf; set => diminutifPromProf = value; }
        public int IdPromotion { get => idpromotion; set => idpromotion = value; }
        public List<User> ListUserPromotionProf { get => listUserpromotionprof; set => listUserpromotionprof = value; }
        public string PromotionName { get => promotionName; set => promotionName = value; }
        public int NombreTotal { get => nombreTotal; set => nombreTotal = value; }

        public PromotionProf(string promotionname, string diminutifprof, int nombreTotal, int idPRomotion)
        {
            PromotionName = promotionname;
            this.diminutifPromProf = diminutifprof;
            NombreTotal = nombreTotal;
            ListUserPromotionProf = new List<User>();
            this.idpromotion = idPRomotion;
        }
        public void AddUser(User u)
        {
            this.listUserpromotionprof.Add(u);
            NombreTotal = listUserpromotionprof.Count();
        }
    }
}
