using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace Models
{
    public class QuestionReponseUnique :Question
    {
        private List<string> m_option;

        private string m_bonneReponse;
        public string Enonce { get; }
        public string BonneReponse
        {
            get { return m_bonneReponse; }
            set
            {
                if (!Options.Contains(value))
                    throw new ArgumentException();
                m_bonneReponse = value;
            }
            }
        public Categorie Categorie { get; set; }
        public int Points { get; }
        
        
        public List<string> Options
        {
            get { return m_option; }
            set
            {
                if (value == null) { throw new ArgumentNullException(); }

                if (value.Count < 2)
                {
                    throw new ArgumentException("Il faut au moins 2 options.");
                }

                m_option = value;
            }
        }
        public QuestionReponseUnique(string enonce, Categorie categorie, int points,
     string bonneReponse, List<string> options)  
     : base(enonce, categorie, points)
        {
            Options = options;          
            BonneReponse = bonneReponse;

            
        }
        public override double CorrigerReponse(string reponse)
        {
            if (reponse == null) return 0;
            if (ValiderReponse(reponse)) return Points;
            return 0;
        }

        public override bool ValiderReponse(string reponse)
        {
            if (reponse == null) return false;
            return reponse.Trim().ToLower() == BonneReponse.Trim().ToLower();
        }

        public void MelangerOptions() { }

    }
}
