using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IReponseAvecIndice
    {
      
        public string Indice
        {
            get;
           
        }



        double PenaliteIndice
        {
            get;

        }
        public bool IndiceUtilise {  get; }
        public  void utiliseIndice() { }

    }
}
