using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class QuestionReponseCourte : Question, IReponsecs
    {
        private string m_bonneReponse;
        string Indice { get; }
        string IndiceUtilise { get; }
        double PenaliteIndice { get; }

        public string Enonce { get; set; }
        public Categorie Categorie { get; set; }
        public int Points { get; set; }
        public string BonneReponse
        {
            get { return m_bonneReponse; }
            set { m_bonneReponse = value; }
        }



        public QuestionReponseCourte(string enonce,
                                Categorie categorie,
                                int points,
                                string bonneReponse)

        {
            Enonce = enonce;
            Categorie = categorie;
            Points = points;
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
        void UtiliserIndice();


    }
}
