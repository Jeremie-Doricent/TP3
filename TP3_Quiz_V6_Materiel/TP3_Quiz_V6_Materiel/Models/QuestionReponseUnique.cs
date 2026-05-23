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
            set { m_bonneReponse = value; }
        }
        public Categorie Categorie { get; set; }
        public int Points { get; }
        public List<string> Option { get; set; }
        public QuestionReponseUnique(string enonce,
                               Categorie categorie,
                               int points,
                               string bonneReponse,List<string> pOtion)

        {
            Enonce = enonce;
            Categorie = categorie;
            Points = points;
            BonneReponse = bonneReponse;
            Option = pOtion;
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
