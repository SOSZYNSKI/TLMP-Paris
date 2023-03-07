using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLMP_Paris.Classe
{
    public class Pari
    {
        DateTime dateMax;
        DateTime dateMatch;
        int resultMatch;
        int pointsEarn;
        int idPari;
        string libelle;
        int range;
        string rangelibelle;
        int penality;
        int elimination;

        public int Elimination { get => elimination; set => elimination = value; }
        public string Rangelibelle { get => rangelibelle; set => rangelibelle = value; }
        public int Range { get => range; set => range = value;}
        public int Penality {  get => penality; set => penality = value; }
        public DateTime DateMax { get => dateMax; set => dateMax = value; }
        public DateTime DateMatch { get => dateMatch; set => dateMatch = value; }
        public int ResultMatch { get => resultMatch; set => resultMatch = value; }
        public int PointsEarn { get => pointsEarn; set => pointsEarn = value; }
        public int IdPari { get => idPari; set => idPari = value; }
        public string Libelle { get => libelle; set => libelle = value; }

        public Pari(DateTime datemax, DateTime datematch, string libelles, int pointearn,int range, string rangelibelle, int penality, int elimination)
        {
            this.DateMax = datemax;
            this.Rangelibelle = rangelibelle;
            this.DateMatch = datematch;
            this.PointsEarn = pointearn;
            this.Libelle = libelles;
            this.Range = range;
            this.Penality = penality;
            this.Elimination = elimination;

        }

        public string SetPari()
        {
            return "Date max du pari : " + this.DateMax + ", Date du match : " + this.DateMatch + ", le résultat du paris est : " + this.ResultMatch + ", le taux de point gagnable est de : " + this.PointsEarn + " et pour finir le paris à comme id : " + this.IdPari + " et a comme libelle : " + this.Libelle;
        }

        public void Sustraction()
        {
            this.PointsEarn -= this.penality;
        }
    }
}
