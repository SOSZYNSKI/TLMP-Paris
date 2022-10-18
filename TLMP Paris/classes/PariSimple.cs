using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLMP_Paris.Classe
{
    internal class PariSimple : Pari
    {
        int eliminations;
        public int Eliminations { get => eliminations; set => eliminations = value; }
        public PariSimple(int elimination,DateTime dateMax,DateTime DateMatch,string libelles,int pointearn, int idparis):base(dateMax,DateMatch,libelles,pointearn,idparis)
        {
            this.Eliminations = elimination;
        }
        public void setResult(int result)
        {
            this.ResultMatch = result;
        }
    }
}
