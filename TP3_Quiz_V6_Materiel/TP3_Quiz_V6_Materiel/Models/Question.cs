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
        private string m_enonce;
        private int m_point;
        public string Enonce
        {
            get { return m_enonce; }
            set
            {
                if (value.Trim() == null || value.Trim() == "")
                { throw new ArgumentException(); }
                m_enonce = value.Trim();
            }
        }

        public Categorie Categorie { get; }
        public int Points
        {
            get { return m_point; }
            set
            {
                if (value < 0)
                { throw new ArgumentException(); }

                m_point = value;
            }

        }
        public List<string> Option { get; }
        public abstract bool ValiderReponse(string reponse);
        public abstract double CorrigerReponse(string reponse);
    }
}
