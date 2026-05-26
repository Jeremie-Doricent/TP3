using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class QuestionReponsesMultiples : Question
    {
        private List<string> m_bonneReponse;

        private List<string> m_option;
        public string Enonce { get; set; }
        public Categorie Categorie { get; set; }
        public int Points { get; set; }
        public List<string> BonneReponse
        {
            get { return m_bonneReponse; }
            set { 
                if(value == null  )
                {
                    throw new ArgumentNullException();
                }
                if(value.Count == 0)
                {
                    throw new ArgumentException();
                }
                foreach (string rep in value)
                {
                    if (!Options.Contains(rep))
                        throw new ArgumentException();
                    
                }

                m_bonneReponse = value;
            }
        }
        public List<string> Option {  get; set; }

        public QuestionReponsesMultiples(string enonce, Categorie categorie, int points,
     List <string> bonneReponse, List<string> options)  
      : base(enonce, categorie, points)
        {
            Options = options;          
            BonneReponse = bonneReponse;
        }
        public List<string> Options
        {
            get { return m_option; }
            set
            {
                if (value == null ) { throw new ArgumentNullException(); }

                if (value.Count < 2)
                {
                    throw new ArgumentException();
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

            List<string> reponsesEleve = new List<string>(reponse.Split(','));

            if (reponsesEleve.Count != BonneReponse.Count) return false;

            foreach (string rep in reponsesEleve)
            {
                if (!BonneReponse.Contains(rep.Trim()))
                    return false;
            }

            return true;
        }

        

        public  void MelangerOptions(List<string>liste) 
        {
            Random random = new Random();
            int nbPermutations = liste.Count * 4;

            for (int k = 0; k < nbPermutations; k++)
            {
                int i = random.Next(liste.Count);
                int j = random.Next(liste.Count);

                string temp = liste[i];
                liste[i] = liste[j];
                liste[j] = temp;
            }
        }
    }
}
