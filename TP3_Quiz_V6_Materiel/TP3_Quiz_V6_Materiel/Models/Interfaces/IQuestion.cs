using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IQuestion
    {
      public  string Enonce { get;  }   
        
       public Categorie Categorie { get;  }
       public int Points { get;  }

       public bool ValiderReponse(string reponse);
       public double CorrigerReponse(string reponse);
    }
   
}
