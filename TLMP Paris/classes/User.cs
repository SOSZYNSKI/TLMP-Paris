using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLMP_Paris.Classe
{
    internal class User
    {
        string userName;
        string secondName;
        int numberWinParis;
        string userPassword;
        string userLogin;
        int totalPoint;
        int idUser;
        public Dictionary<Pari, int> Paris { get => paris; set => paris = value; }
        public int IdUser { get => idUser; set => idUser = value; }
        public string UserName { get => userName; set => userName = value; }
        public string SecondName { get => secondName; set => secondName = value; }
        public int NumberWinParis { get => numberWinParis; set => numberWinParis = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }
        public string UserLogin { get => userLogin; set => userLogin = value; }
        public int TotalPoint { get => totalPoint; set => totalPoint = value; }
        public Promotion Promotion { get => promotion; set => promotion = value; }

        Dictionary<Pari, int> paris;
        Promotion promotion;

        public User(string username, string secondname, int numberwinparis, string userpassword, string userlogin, int totalpoint, int iduser)
        {
            this.UserName = username;
            this.SecondName = secondname;
            this.NumberWinParis = numberwinparis;
            this.UserPassword = userpassword;
            this.UserLogin = userlogin;
            this.TotalPoint = totalpoint;
            this.IdUser = iduser;
            this.Paris = new Dictionary<Pari, int>();
        }

        public void Parier(Pari p, int userInformation)
        {
            paris.Add(p, userInformation);
        }

        public void SetPromotion(Promotion p)
        {
            this.Promotion = p;
        }
    }
}
