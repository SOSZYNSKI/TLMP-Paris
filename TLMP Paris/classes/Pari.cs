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
        DateTime range;
        int penality;
        int elimination;

        public int Elimination { get => elimination; set => elimination = value; }
        public DateTime Range { get => range; set => Range = value;}
        public int Penality {  get => penality; set => penality = value; }
        public DateTime DateMax { get => dateMax; set => dateMax = value; }
        public DateTime DateMatch { get => dateMatch; set => dateMatch = value; }
        public int ResultMatch { get => resultMatch; set => resultMatch = value; }
        public int PointsEarn { get => pointsEarn; set => pointsEarn = value; }
        public int IdPari { get => idPari; set => idPari = value; }
        public string Libelle { get => libelle; set => libelle = value; }

        public Pari(DateTime datemax, DateTime datematch,string libelles, int pointearn,int elimination, DateTime range, int penality)
        {
            this.DateMax = datemax;
            this.DateMatch = datematch;
            this.PointsEarn = pointearn;
            this.Libelle = libelles;
            this.Elimination = elimination;
            this.Range = range;
            this.Penality = penality;
        }

        public Pari(DateTime datemax, DateTime datematch,string libelles,int pointearn,int elimination)
        {
            this.DateMax = datemax;
            this.DateMatch = datematch;
            this.PointsEarn = pointearn;
            this.Libelle = libelles;
            this.Elimination = elimination;
        }

        public Pari(DateTime datemax, DateTime datematch, string libelles, int pointearn,DateTime range, int penality)
        {
            this.DateMax = datemax;
            this.Libellerange = libellerange;
            this.DateMatch = datematch;
            this.PointsEarn = pointearn;
            this.Libelle = libelles;
            this.Range = range;
            this.Penality = penality;

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
