using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class QuestionReponseMultiples : Question
    {
        private List<string> m_bonneReponse;

        private List<string> m_option;
        public string Enonce { get; set; }
        public Categorie Categorie { get; set; }
        public int Points { get; set; }
        public List<string> BonneReponse
        {
            get { return m_bonneReponse; }
            set { m_bonneReponse = value; }
        }

        public List<string> Option {  get; set; }

        public QuestionReponseMultiples(string enonce, Categorie categorie, int points,
     List<string> bonneReponse, List<string> options)

        {
            Enonce = enonce;
            Categorie = categorie;
            Points = points;
            BonneReponse = bonneReponse;
            Option = options;
        }
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
        public abstract void MelangerOptions();
    }
}
