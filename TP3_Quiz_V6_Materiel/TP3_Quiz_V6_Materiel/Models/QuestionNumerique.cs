using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
        public  class QuestionNumerique :Question , IReponseAvecIndice
    {
        private double m_penaliteIndice;
        private string m_indice;
        private double m_bonneReponse;
      public  string Indice
        {
            get { return m_indice; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("L'indice ne peut pas être null, vide ou espaces.");
                m_indice = value;
            }
        }
        
        

           public double PenaliteIndice { get {return m_penaliteIndice ; } set
            {
                if (value < 0 || value > 1)
                    throw new ArgumentOutOfRangeException("La pénalité doit être entre 0 et 1.");
                m_penaliteIndice = value;
            }
        }
        public bool IndiceUtilise { get; set; }
       

        public string Enonce { get; set; }
        public Categorie Categorie { get; set; }
        public int Points { get; set; }
        public double BonneReponse
        {
            get { return m_bonneReponse; }
            set { m_bonneReponse = value; }
        }



        public QuestionNumerique(string enonce, Categorie categorie, int points, double bonneReponse)
    : base(enonce, categorie, points) 
        {
            BonneReponse = bonneReponse;  
        }
        public override double CorrigerReponse(string reponse)
        {
            bool estValide = double.TryParse(reponse, out double val);
            if (!estValide) return 0;

            return val == BonneReponse ? Points : 0;
        }

        public override bool ValiderReponse(string reponse)
        {
            bool estDouble = double.TryParse(reponse, out double val);
            if (estDouble)
                return val == BonneReponse;

            return false;
        }
        public void UtiliserIndice()
        {
            IndiceUtilise = true;
        }

    }
}
