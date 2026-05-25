using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class QuestionReponseCourte : Question, IReponseAvecIndice
    {
        private double m_penaliteIndice;
        private string m_indice;
        private string m_bonneReponse;
        public string Indice
        {
            get { return m_indice; }
            set
            {
                if (value == null || value =="")
                    throw new ArgumentException();
                m_indice = value;
            }
        }



      public  double PenaliteIndice
        {
            get { return m_penaliteIndice; }
            set
            {
                if (value < 0 || value > 1)
                    throw new ArgumentOutOfRangeException("La pénalité doit être entre 0 et 1.");
                m_penaliteIndice = value;
            }
        }

        
        public string BonneReponse
        {
            get { return m_bonneReponse; }
            set {
                if(value == null || value == "")
                {
                    throw new ArgumentException();
                }
                
                m_bonneReponse = value; }
        }
        public bool IndiceUtilise { get; set; }



        public QuestionReponseCourte(string enonce, Categorie categorie, int points,
      string bonneReponse, string indice, double penaliteIndice)
      : base(enonce, categorie, points)
        {
            BonneReponse = bonneReponse;
            Indice = indice;
            PenaliteIndice = penaliteIndice;
        }
        public override double CorrigerReponse(string reponse)
        {
            if (reponse == null) return 0;
            if (ValiderReponse(reponse))
            {
                if (IndiceUtilise == true)
                {
                    return Points * PenaliteIndice;
                }
                return Points;
            }
            return 0;
        }

        public override bool ValiderReponse(string reponse)
        {
            if (reponse == null) return false;
            return reponse.Trim().ToLower() == BonneReponse.Trim().ToLower();
        }
         public void UtiliserIndice() { 
        IndiceUtilise = true;
        }


    }
}
