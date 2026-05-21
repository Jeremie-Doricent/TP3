using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal interface IReponsecs
    {
       public string Indice {  get; set; }
        public bool IndiceUtilise { get; set; }
        public double PenaliteIndice { get; set; }

        public void utiliserindice()
        {

        }
    }
}
