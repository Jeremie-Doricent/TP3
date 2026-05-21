using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using Models.Interfaces;

namespace Models
{
    public class QuestionReponseUnique : Question
    { Question sq = new Question();

        private List<string> m_unique;
        string Enonce { get; set; }

        Categorie Categorie { get; set; }
        int Points { get; }

        int BonneReponse { get; set; }
        bool ValiderReponse(string reponse);
        double CorrigerReponse(string reponse);

        public List<string> option { get {return m_unique ; }
            set { if (value == null) 
                { throw new ArgumentNullException(); }


              


            } }
    }
}

