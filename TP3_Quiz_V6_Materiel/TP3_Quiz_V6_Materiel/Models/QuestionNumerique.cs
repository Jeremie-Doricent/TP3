using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
        public  class QuestionNumerique :Question , IReponsecs
    {
        private double m_bonneReponse;
        string Indice { get; }
        string IndiceUtilise { get; }
        double PenaliteIndice { get; }

        public string Enonce { get; set; }
        public Categorie Categorie { get; set; }
        public int Points { get; set; }
        public double BonneReponse
        {
            get { return m_bonneReponse; }
            set { m_bonneReponse = value; }
        }



        public QuestionNumerique(string enonce,
                                Categorie categorie,
                                int points,
                                double bonneReponse)

        {
            Enonce = enonce;
            Categorie = categorie;
            Points = points;
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
        void UtiliserIndice();
    }
}
