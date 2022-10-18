using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLMP_Paris.Classe
{
    internal class PariSpe : Pari
    {
        DateTime range;
        int penality;
        public DateTime Range { get => range; set => range = value; }
        public int Penality { get => penality; set => penality = value; }

        public PariSpe (DateTime NewRange, int NewPenality,DateTime DateMax,DateTime DateMAtch,string libelle,int pointearn, int idpari) : base(DateMax,DateMAtch,libelle,pointearn,idpari)
        {
            this.Range = NewRange;
            this.Penality = NewPenality;
        }

        public override string ToString()
        {
            return "Ce pari est-un pari spéciale, il prend fin le : " + this.DateMax + " Le match sera le : " + this.DateMatch + " et aura comme libelle " + this.Libelle + " il aura comme récompense : " + this.PointsEarn + " points gagnable, il aura une pénalité de : " + this.penality + " points pour chaque dépassement équivalent à la rage : " + this.range;
        }
        public void SetResult(int result)
        {
            this.ResultMatch = result;
        }
        public void Sustraction()
        {
            this.PointsEarn -= this.penality;
        }
    }
}
