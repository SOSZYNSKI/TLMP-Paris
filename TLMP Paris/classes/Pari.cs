using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLMP_Paris.Classe
{
    internal class Pari
    {
        DateTime dateMax;
        DateTime dateMatch;
        int resultMatch;
        int pointsEarn;
        int idPari;
        string libelle;
        public DateTime DateMax { get => dateMax; set => dateMax = value; }
        public DateTime DateMatch { get => dateMatch; set => dateMatch = value; }
        public int ResultMatch { get => resultMatch; set => resultMatch = value; }
        public int PointsEarn { get => pointsEarn; set => pointsEarn = value; }
        public int IdPari { get => idPari; set => idPari = value; }
        public string Libelle { get => libelle; set => libelle = value; }

        public Pari(DateTime datemax, DateTime datematch,string libelles, int pointearn, int idpari)
        {
            this.DateMax = datemax;
            this.DateMatch = datematch;
            this.PointsEarn = pointearn;
            this.IdPari = idpari;
            this.Libelle = libelles;
        }

        public string SetPari()
        {
            return "Date max du pari : " + this.DateMax + ", Date du match : " + this.DateMatch + ", le résultat du paris est : " + this.ResultMatch + ", le taux de point gagnable est de : " + this.PointsEarn + " et pour finir le paris à comme id : " + this.IdPari + " et a comme libelle : " + this.Libelle;
        } 
    }
}
