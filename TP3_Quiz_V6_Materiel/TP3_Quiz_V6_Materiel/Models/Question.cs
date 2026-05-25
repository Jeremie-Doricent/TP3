using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract  class Question : IQuestion
    {
        private double m_bonneReponse;
        private string m_enonce;
        private int m_point;
        public virtual string Enonce
        {
            get { return m_enonce; }
            set
            {
                if (value.Trim() == null || value.Trim() == "")
                { throw new ArgumentException(); }
                m_enonce = value.Trim();
            }
        }

        public virtual Categorie Categorie { get; }
        public virtual int Points
        {
            get { return m_point; }
            set
            {
                if (value <= 0)
                { throw new ArgumentOutOfRangeException(); }

                m_point = value;
            }

        }
        public double BonneReponse
        {
            get { return m_bonneReponse; }
            set { m_bonneReponse = value; }
        }

        public Question(string enonce, Categorie categorie, int points)
        {
            Enonce = enonce;
            Categorie = categorie;
            Points = points;
        }

     
        public abstract bool ValiderReponse(string reponse);
        public abstract double CorrigerReponse(string reponse);
    }
}
